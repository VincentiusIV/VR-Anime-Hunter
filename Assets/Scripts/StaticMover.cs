using UnityEngine;

public class StaticMover : MonoBehaviour
{
    // A simple script that moves an object along the z axis in a constant speed

    public float speed;

    public bool y;
	// Update is called once per frame
	void Update ()
    {
        if (y)
        {
            transform.Translate(0, Time.deltaTime * -speed, 0);
        }
        else
        {
            transform.Translate(0, 0, Time.deltaTime * -speed);
        }
	}
}
