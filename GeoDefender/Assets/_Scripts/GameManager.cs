using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] asteroidArray;
    [SerializeField]
    private GameObject[] powerUpArray;

    private int asteroidTotalSize;
    private int wave;

    private bool gameRunning;
    private float powerUpTimer;
    private bool powerUpOnField;

    [SerializeField]
    private Text waveText;

    private static int[][] spawnArray = new int[][]{
        new int[]{ 3, 0, 0, 0},
        new int[]{ 2, 1, 0, 0},
        new int[]{ 1, 3, 0, 0},
        new int[]{ 0, 0, 1, 0},
        new int[]{ 1, 1, 1, 0},
        new int[]{ 0, 1, 2, 0},
        new int[]{ 2, 1, 0, 1},
        new int[]{ 1, 1, 1, 1},
        new int[]{ 2, 2, 2, 4},
    };


    // Use this for initialization
    void Start()
    {
        wave = 0;
        gameRunning = true;
        foreach (GameObject powerUp in powerUpArray)
        {
            powerUp.SetActive(false);
        }
        powerUpTimer = 0f;
        waveText.text = "Wave - " + (wave + 1).ToString();
        powerUpOnField = false;
        Invoke("SpawnNewWave", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning)
        {
            SpawnPowerUp();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    private Vector3 GenerateRandomSpawnPoint()
    {
        int mod1 = Random.Range(0, 2) * 2 - 1;
        int mod2 = Random.Range(0, 2) * 2 - 1;
        Vector3 returnVector = new Vector3(Random.Range(3f, 14f) * mod1, Random.Range(3f, 9f) * mod2, 0f);
        return returnVector;
    }

    private void SpawnPowerUp()
    {
        if (!powerUpOnField)
        {
            powerUpTimer += Time.deltaTime;

            if (powerUpTimer > 20 || Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("spawn pu");
                powerUpTimer = 0;
                int index = Random.Range(0, powerUpArray.Length);
                powerUpArray[index].SetActive(true);
                powerUpArray[index].GetComponent<AsteroidMovement>().RandomVelocityVector();
                powerUpOnField = true;
            }
        }
    }


    public void PowerUpConsumed()
    {
        powerUpOnField = false;
    }

    public void ReduceTotalSize()
    {
        asteroidTotalSize--;
        if (asteroidTotalSize == 0)
        {
            wave++;
            Debug.Log("Wave cleared!");
            //reset TotalSize, spawn asteroids
            Invoke("SpawnNewWave", 3f);
        }
    }

    private void SpawnNewWave()
    {
        ResetPlayerPosition();
        waveText.text = "Wave - " + (wave + 1).ToString();
        if (wave == 9)
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadNextLevel();
        }
        for (int j = 0; j < spawnArray[wave].Length; j++)
        {
            for (int i = 0; i < spawnArray[wave][j]; i++)
            {
                GameObject obj = Instantiate(asteroidArray[j], GenerateRandomSpawnPoint(), Quaternion.identity, GameObject.Find("AsteroidField").transform);
                obj.GetComponent<AsteroidData>().InitAsteroid(j + 1);
                obj.GetComponent<AsteroidMovement>().SetVelocity(Vector3.up, Quaternion.Euler(0, 0, Random.Range(0, 360f)), Quaternion.identity);
            }
            asteroidTotalSize += System.Convert.ToInt32(Mathf.Pow(2, j) * spawnArray[wave][j]);
        }
    }
    private void ResetPlayerPosition()
    {
        GameObject.Find("Player Spaceship").transform.position = Vector3.zero;
        GameObject.Find("Player Spaceship").GetComponent<PlayerMovement>().ResetVelocity();
    }

}
