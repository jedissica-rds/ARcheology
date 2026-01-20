using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractor : MonoBehaviour, IInteractable
{
    private Animator animator;

    private bool isHeld = false;

    private bool isLocked = false;

    private bool isScanned = false;

    private bool isTouched = false;

    [SerializeField] private SOObjectInfo objectInfo;
    [SerializeField] private float infoDisplayHeight = 2f;

    private IInteractionBehaviour[] behaviours;

    private void Awake()
    {
        behaviours = GetComponents<IInteractionBehaviour>();

        animator = GetComponent<Animator>();
    }

    public void OnInteract()
    {
        if (isLocked) return;

        if (!isHeld && HoldingManager.Instance.TryToPickUp(gameObject))
        {
            isHeld = true;
            isTouched = true;

            ShowObjectInfo();

            foreach (var behaviour in behaviours)
                behaviour.OnPickUp();

            if (animator != null)
            {
                animator.SetBool("isTouched", true);
                animator.speed = 0;
            }
        }
        else if (isHeld)
        {
            HoldingManager.Instance.Drop();
            isHeld = false;
            isTouched = false;

            HideObjectInfo();

            foreach (var behaviour in behaviours)
                behaviour.OnDrop();

            if (animator != null)
            {
                animator.SetBool("isTouched", false);
                animator.speed = 1;
            }
        }
    }


    public void StopInteract()
    {
        isTouched = false;
        Debug.Log("Parando de interagir com o cubo!");
    }

    // Update is called once per frame
    void Update()
    {
        if (InputHandler.TryRayCastHit(out RaycastHit hitObject))
        {
            if (hitObject.transform == transform)
            {
                OnInteract();
            }
        }

    }

    private void ShowObjectInfo()
    {
        Debug.Log("Obtendo informações do objeto...");

        if (objectInfo == null || isScanned == false) return;

        Debug.Log("Mostrando informações do objeto...");

        var infoController = FindObjectOfType<ObjectInfoController>();

        if (infoController != null)
        {

            Debug.Log("Definindo informações do objeto...");
            infoController.SetObjectInfo(objectInfo);
            infoController.setVisible(true);

            infoController.transform.SetParent(transform);
            infoController.transform.localPosition = new Vector3(0, infoDisplayHeight, 0);
        }
    }

    private void HideObjectInfo()
    {
        var infoController = FindObjectOfType<ObjectInfoController>();

        if (infoController != null)
        {
            infoController.setVisible(false);
            infoController.transform.SetParent(null);
        }
    }
    
    public void SetLocked(bool locked=true)
    {
        isLocked = locked;
    }

    public void setScanned(bool scanned=true)
    {
        isScanned = scanned;
    }

}
