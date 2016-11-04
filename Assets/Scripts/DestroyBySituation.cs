using UnityEngine;

public class DestroyBySituation : MonoBehaviour
{
    /* A very useful script that destroys game objects based on trigger colliders
     * 
     * Whenever a collider hits a trigger collider with this script, the other collider
     * will be stored and tags will be compared. 
     * 
     * Since an object can only have one tag, return is used to end the function whenever
     * a CompareTag returns true
     * 
     * Some situations require the GameController to addscore or addbuff. 
     * GameController is searched and stored in the Start() function.
     * */
    public GameObject explosion;

    private GameObject _GCObject;
    private GameController gameController;

    private float negativeDestroyBoundary = -10;
    private float positiveDestroyBoundary = 150;

    void Start()
    {
        _GCObject = GameObject.FindWithTag("GameController");
        gameController = _GCObject.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If this object is a Pick Up, destroy it and call AddBuff() function in game controller
        if(this.CompareTag("Pick Up"))
        {
            Destroy(this.gameObject);
            gameController.AddBuff();
            return;
        }

        // If other gameobject is the Player, create an explosion
        if(other.CompareTag("Player"))
        {
            CreateExplosion(other.transform.position);
            Destroy(other.gameObject);
            gameController.GameOver();

            // If this game object is also an enemy, then create an explosion as well
            if (this.CompareTag("Enemy"))
            {
                CreateExplosion(transform.position);
                Destroy(this.gameObject);
            }
            return;
        }

        /* If other game object is a bolt, and this is an enemy, 
         * destroy both objects and create an explosion on the enemy position
         */
        if(other.CompareTag("Bolt") && this.CompareTag("Enemy"))
        {
            CreateExplosion(transform.position);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            gameController.IncreaseScore(10);
            return;
        }
    }

    /* This checks the z position of the object, and destroys it once it
     * surpasses the negative or positive boundary value.
     */
    void Update()
    {
        if(transform.position.z < negativeDestroyBoundary || transform.position.z > positiveDestroyBoundary)
        {
            Destroy(this.gameObject);
        }
    }

    /* CreateExplosion function is not necessary, but since the same code
     * is used multiple times this just helps to clean up the script.
     * 
     * It instantiates an explosion if the explosion variable is not null
     * 
     * If you dont want to create an explosion, then leave the public var
     * 'explosion' in the Unity editor empty.
     */
    void CreateExplosion(Vector3 _pos)
    {
        if(explosion != null)
        {
            Instantiate(explosion, _pos, Quaternion.identity);
        }
    }
}
