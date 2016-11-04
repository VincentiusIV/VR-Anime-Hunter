using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ViveGun : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    public Transform shotSpawn;
    public GameObject shot;
    public AudioSource weaponAudio;

    public Transform playerTransform;
    public bool left;
    public bool right;
    public float speed;
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

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log("you held grip button");
            if (left)
            {
                Debug.Log("you held left grip button");
                playerTransform.Translate(new Vector3(-speed, 0.0f, 0.0f));
            }
            else if(right)
            {
                Debug.Log("you held right grip button");
                playerTransform.Translate(new Vector3(speed, 0.0f, 0.0f));
            }
            
        }
    }
}
