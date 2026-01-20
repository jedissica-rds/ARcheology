using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScannerController : MonoBehaviour
{
    [SerializeField] private SpotController spot;
    [SerializeField] private float scanDuration = 4f;

    [SerializeField] GameObject scanUI;

    private Animator animator;

    void Start()
    {
        if (GetComponent<Animator>() != null)
        {
             animator = GetComponent<Animator>();
        }
        else 
        {
            Debug.LogWarning("Animator component not found on ScannerController GameObject.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            TryToPutOnSpot(collision.gameObject);
        }
    }

    void TryToPutOnSpot(GameObject obj)
    {
        if(!spot.isOccupied())
        {

            obj.transform.SetParent(spot.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

            if (obj.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.isKinematic = true;
            }

            if (obj.TryGetComponent(out ObjectInteractor interactor))
            {
                StartCoroutine(StartScanning(interactor));
            }
        }
    }

    private IEnumerator StartScanning(ObjectInteractor interactor)
    {
        Debug.Log("Started Scanning...");
        animator.SetBool("isScanning", true);
        scanUI.SetActive(false);
        interactor.SetLocked(true);
        interactor.setScanned(false);
        yield return new WaitForSeconds(scanDuration);
        Debug.Log("Scanning Complete!");
        animator.SetBool("isScanning", false);
         scanUI.SetActive(true);
        interactor.SetLocked(false);
         interactor.setScanned(true);
    }
}