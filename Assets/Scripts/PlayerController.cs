using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* PlayerController script that allows the player to move the horse left and right, and shoot.
     */
    public float speed;

    public GameObject ammunition;
    public Transform ammoSpawnLocation;
    public float wForShot;
    public AudioSource weaponAudio;

    private float nextShot;

    void Update ()
    {
        /* float h = Input.GetAxis("Mouse X") /3;
         * This axis could be used instead of the Horizontal axis to allow the cursor
         * to move the horse. However, this input is extremely buggy.
         * When used, the camera is stuttering and the player is able to force through collisions
         * Furthermore, steering with the mouse just felt awkward. 
         * That is why I prefer the keyboard input, instead of the cursor.
         */

        float h = Input.GetAxis("Horizontal");
        Vector3 sMovement = new Vector3(h, 0.0f, 0.0f);
        
        // Movement is made proporionate to the given speed and deltaTime.
        transform.Translate(sMovement * speed * Time.deltaTime);

        if(Input.GetButton("Fire1") && Time.time > nextShot)
        {
            nextShot = Time.time + wForShot;
            Instantiate(ammunition, ammoSpawnLocation.position, ammoSpawnLocation.rotation);
            weaponAudio.Play();
        }
    }
}
