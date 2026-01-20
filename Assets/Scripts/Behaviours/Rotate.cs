using UnityEngine;

public class RotateOnInteractBehaviour : MonoBehaviour, IInteractionBehaviour
{
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private bool rotateWhileHeld = true;

    private bool isRotating = false;

    public void OnPickUp()
    {
        if (!rotateWhileHeld) return;
        isRotating = true;
    }

    public void OnDrop()
    {
        isRotating = false;
    }

    private void Update()
    {
        if (!isRotating) return;

        transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
