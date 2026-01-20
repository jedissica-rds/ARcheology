
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpotController : MonoBehaviour
{
    public bool isOccupied() 
    {
        return transform.childCount > 0;
    }
}