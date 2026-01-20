using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InitialSetup : MonoBehaviour
{

    // Tamanho necessário
    [SerializeField] private float requiredArea;

    //Controla o plano
    [SerializeField] private ARPlaneManager planeManager;

    //Menu que aparece com o plano
    [SerializeField] private GameObject startExperienceUI;

    [SerializeField] StartExperience startExperience;

    void OnEnable()
    {
        planeManager.planesChanged += OnPlanesUpdated;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesUpdated;
    }

    public void OnClickStartExperience()
    {
        Debug.Log("Inicializando a experiência AR...");
        startExperienceUI.SetActive(false);
        planeManager.enabled = false;

        startExperience.onStart(GetBiggestPlane());
    }

    private void OnPlanesUpdated(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.updated) 
        {

            if (plane.extents.x * plane.extents.y >= requiredArea) 
            {
                //Encontrei um plano
                startExperienceUI.SetActive(true);
            }

        }
        
    }

    //pegar maior plano
    private ARPlane GetBiggestPlane()
    {
        ARPlane biggestPlane = null;
        float biggestArea = 0f;

        foreach (var plane in planeManager.trackables)
        {
            float area = plane.extents.x * plane.extents.y;
            if (area > biggestArea)
            {
                biggestArea = area;
                biggestPlane = plane;
            }
        }
        return biggestPlane;
    }

    
}
