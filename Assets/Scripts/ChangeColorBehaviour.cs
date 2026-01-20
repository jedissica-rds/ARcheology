using UnityEngine;

public class ChangeColorOnPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] private Color pickUpColor = Color.red;

     [SerializeField] private GameObject obj;

    private Color originalColor;
    private Renderer rend;

    private void Awake() 
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            originalColor = rend.material.color;
    }

    public void OnInteract()
    {
        if (rend != null)
            rend.material.color = pickUpColor;
            Debug.Log("Mudando de cor");
    }

    public void StopInteract()
    {
        if (rend != null)
            rend.material.color = originalColor;
    }
}
