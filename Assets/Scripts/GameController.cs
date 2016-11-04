using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


/* A seperate class for WaveSettings to make the inspector in Unity
 * more organized
 */

[System.Serializable]
public class WaveSettings
{
    public float startWait, waveWait, timeBetweenSpawn, zPosSpawn;
    public int enemiesPerWave, extraEnemiesPerWave;
}

public class GameController : MonoBehaviour
{
    /* Largest script of this game that spawns enemies and pickups,
     * adds score, updates text (score, timer, restart) and gives the player
     * the option to restart or return to menu when the game is over.
     */
    public GameObject player;
    public GameObject[] enemies;
    public GameObject[] pickUps;
    public AudioSource pickUpSound;

    public WaveSettings WaveSettings;

    public Text scoreText;
    public Text restartText;
    public Text timerText;

    private int score;
    private float counter;
    private bool gameRunning;
    private Vector3 spawnPos;
    private int random;

	// Start is used for initialisation
    void Start()
    {
        StartCoroutine(WaveSpawner());
        gameRunning = true;

        score = 0;
        scoreText.text = "Score: " + score;
        restartText.text = "";
        counter = 0f;
    }

    /* Coroutine that spawns the waves of enemies and pick ups
     * 
     * All enemy prefabs are taken randomly from the enemies array
     * Enemies are instantiated randomly in their designated field (spawnPos)
     * 
     * Spawing waves is done in an IEnumerator so that the function can yield
     */
    IEnumerator WaveSpawner ()
    {
        yield return new WaitForSeconds(WaveSettings.startWait);

        while (gameRunning)
        {
            for (int i = 0; i < WaveSettings.enemiesPerWave; i++)
            {
                SpawnObject(enemies, 5);
                yield return new WaitForSeconds(WaveSettings.timeBetweenSpawn);

                random = Random.Range(0, 4);

                // For every enemy that is spawned, there is a 33% chance on a pickup to spawn as well
                if(random > 2)
                {
                    SpawnObject(pickUps, 1);
                }
                
            }

            //Amount of enemies per wave is increased as time goes on
            WaveSettings.enemiesPerWave += WaveSettings.extraEnemiesPerWave;


            //Time between each spawn is decreased so the waves become more dense
            if(WaveSettings.timeBetweenSpawn > WaveSettings.timeBetweenSpawn / 10)
            {
                WaveSettings.timeBetweenSpawn -= WaveSettings.timeBetweenSpawn / 8;
            }
        }
    }
	
    void Update()
    {
        // Player is able to restart when the game is not running
        if(gameRunning != true)
        {
            if(Input.GetButton("Restart"))
            {
                SceneManager.LoadScene("roadToHell");
            }
        }

        // Player is always able to return to menu
        if(Input.GetButton("Return"))
        {
            SceneManager.LoadScene("mainMenu");
        }

        // Updates the timer only when the game is running
        if(gameRunning)
        {
            counter += Time.time / 600;
            timerText.text = counter + "s";
        }
    }

    // Spawns a random object from given array, on a random location in the spawnarea
    void SpawnObject(GameObject[] _array, float _spawnHeight)
    {
        spawnPos = new Vector3(Random.Range(-8, 8), _spawnHeight, WaveSettings.zPosSpawn);
        Instantiate(_array[Random.Range(0, _array.Length)], spawnPos, Quaternion.identity);
    }

    // This function is called when the player is dead by colliding with an enemy or lamp post
    public void GameOver()
    {
        gameRunning = false;
        restartText.text = "Press 'R' to restart or 'M' for menu";
    }

    // This function is called when a bolt fired by the player hits an enemy
    public void IncreaseScore(int _score)
    {
        score += _score;
        scoreText.text = "Score: " + score;
    }

    // This is called whenever a Pick-Up is picked up by the player
    public void AddBuff()
    {
        pickUpSound.Play();
        IncreaseScore(20);
    }
}
