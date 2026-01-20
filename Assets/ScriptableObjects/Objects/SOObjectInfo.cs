using UnityEngine;

[CreateAssetMenu(fileName = "New Object Info", menuName = "ScriptableObjects/ObjectInfo")]
public class SOObjectInfo : ScriptableObject
{
    public string objectTitle;
    [TextArea]
    public string objectDescription;

    public Sprite icon;

    
}