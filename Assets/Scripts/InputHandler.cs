using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InputHandler
{
    public static bool TryRayCastHit(out RaycastHit hitObject) 
    {
        #if ENABLE_INPUT_SYSTEM
        if (UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame)
        {
            // verifica se o toque foi no obejto
            Ray ray = Camera.main.ScreenPointToRay(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hitObject))
            {
                return true;
            }
        }
        #endif

        // existe dedo na tela e pega o rpimeiro toque e se ele começou
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // verifica se o toque foi no obejto
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hitObject))
            {
                return true;
            }
        }

        hitObject = default;
        return false;

    }
}