using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ViveGun : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    public Transform shotSpawn;
    public GameObject shot;
    public AudioSource weaponAudio;

    // Use this for initialization
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }
    void Update()
    {
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            weaponAudio.Play();
        }
    }

}
