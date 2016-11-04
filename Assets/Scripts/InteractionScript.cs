using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickUpScript : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    // Use this for initialization
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "VrController")
        { return; }
        else
        {
            // runs when trigger is held down
            if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
            {
                
            }

            // runs when trigger is released
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                
            }
        }
    }
}