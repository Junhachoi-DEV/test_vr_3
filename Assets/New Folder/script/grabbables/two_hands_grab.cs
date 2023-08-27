using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class two_hands_grab : XRGrabInteractable
{
    public List<XRSimpleInteractable> seconds_hand_grab_points = new List<XRSimpleInteractable>();
    XRBaseInteractor second_interactor;
    [System.Obsolete]
    void Start()
    {
        
        foreach (var item in seconds_hand_grab_points)
        {
            item.onSelectEnter.AddListener(on_seconds_hand_grab);
            item.onSelectExit.AddListener(on_seconds_hand_release);
        }
    }

    int num = 0;

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(second_interactor && selectingInteractor)
        {
            selectingInteractor.attachTransform.rotation =
                Quaternion.LookRotation(second_interactor.transform.position - selectingInteractor.attachTransform.position);
        }


        base.ProcessInteractable(updatePhase);
    }

    public void on_seconds_hand_grab(XRBaseInteractor interactor)
    {
        //Debug.Log("second hand grab");
        second_interactor = interactor;
    }
    public void on_seconds_hand_release(XRBaseInteractor interactor)
    {
        //Debug.Log("second hand release");
        second_interactor = null;
    }

    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        //Debug.Log("first grab enter");
        base.OnSelectEntered(interactor);
    }

    [System.Obsolete]
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        //Debug.Log("first grab exit");
        base.OnSelectExited(interactor);
        second_interactor = null;
    }
    
    [System.Obsolete]
    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool is_already_grabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        return base.IsSelectableBy(interactor) && !is_already_grabbed;
    }
    
}
