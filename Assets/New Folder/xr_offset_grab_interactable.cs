using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class xr_offset_grab_interactable : XRGrabInteractable
{

    //
    private Vector3 initial_attach_local_pos;
    private Quaternion initial_attach_local_rot;


    void Start()
    {
        //create attach point
        if (!attachTransform)
        {
            GameObject grab = new GameObject("grab pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }

        initial_attach_local_pos = attachTransform.localPosition;
        initial_attach_local_rot = attachTransform.localRotation;
    }

    [System.Obsolete]
    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initial_attach_local_pos;
            attachTransform.localRotation = initial_attach_local_rot;
        }
        base.OnSelectEntering(interactor);
    }
}

