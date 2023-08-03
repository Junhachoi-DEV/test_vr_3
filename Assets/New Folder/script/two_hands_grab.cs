using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class two_hands_grab : XRGrabInteractable
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool is_already_grabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        return base.IsSelectableBy(interactor) && !is_already_grabbed;
    }
}
