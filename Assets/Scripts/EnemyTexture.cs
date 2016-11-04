using UnityEngine;

public class EnemyTexture : MonoBehaviour
{
    /* A simple script for the texture on enemies to always look in the direction of the camera.
     * The rotation is adjusted to only rotate forwards.
     * 
     * This is intentional for the anime characters that will be shot in the game.
     */

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
