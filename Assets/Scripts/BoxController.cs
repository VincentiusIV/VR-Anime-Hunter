using UnityEngine;

public class BoxController : MonoBehaviour
{
    /* A very simple script that rotates an object
     * ,in this case a cube, around the Y-axis
     * */
    public float rotateSpeed;

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0.0f, rotateSpeed, 0.0f));
    }
}
