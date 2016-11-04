using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    /* A script that makes the camera follow the player smoothly
     * 
     * The camera focuses on the target, which is an invisible game object
     * in front of the player.
     * 
     * Smoothing is done using Vector3.Lerp
     */
    public GameObject target;

    public float lerpIntensity;
    public float camHeight = 3.0f;
    public float camDistance = 5.0f;

    private Camera cam;

	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
        cam.fieldOfView = 90f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(target != null)
        {
            Vector3 cameraPosition = target.transform.position - Vector3.forward * camDistance - Vector3.down * camHeight;
            transform.position = Vector3.Lerp(transform.position, cameraPosition, lerpIntensity);
            transform.LookAt(target.transform);
        }
	}
}
