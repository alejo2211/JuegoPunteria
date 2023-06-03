using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Derecha : MonoBehaviour
{
    public InputActionProperty pinchDeracha;
    public InputActionProperty gripDerecha;
    public Animator handAnimator;
    void Start()
    {
        
    }

    
    void Update()
    {
        float triggerValue = pinchDeracha.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

       float gripBlendValue = pinchDeracha.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripBlendValue);
    }
}
