using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectInfoController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image iconImage;

    [SerializeField] private GameObject panel;

    public void setVisible(bool isVisible = true)
    {
       panel.SetActive(isVisible);
    }

    public void SetObjectInfo(SOObjectInfo info)
    {
        titleText.text = info.objectTitle;
        descriptionText.text = info.objectDescription;

        if (iconImage != null)
        {
            iconImage.sprite = info.icon;
            iconImage.enabled = info.icon != null;
        }
    }
}