using UnityEngine;

public class StaticMover : MonoBehaviour
{
    // A simple script that moves an object along the z axis in a constant speed

    public float speed;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0, 0, Time.deltaTime * -speed);
	}
}
