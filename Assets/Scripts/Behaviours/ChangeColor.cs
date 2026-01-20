using UnityEngine;

public class ChangeColorBehaviour : MonoBehaviour, IInteractionBehaviour
{
    [SerializeField] private Color pickedColor = Color.red;

    private Renderer rd;
    private Color originalColor;

    private void Awake()
    {
        rd = GetComponent<Renderer>();
        if (rd != null)
            originalColor = rd.material.color;
    }

    public void OnPickUp()
    {
        if (rd != null)
        Debug.Log("ESTÁ MUDANDO DE COR!");
            rd.material.color = pickedColor;
    }

    public void OnDrop()
    {
        if (rd != null)
            rd.material.color = originalColor;
    }
}
