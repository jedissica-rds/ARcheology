using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    void Update()
    {
        if(Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);
        }
        
    }
}