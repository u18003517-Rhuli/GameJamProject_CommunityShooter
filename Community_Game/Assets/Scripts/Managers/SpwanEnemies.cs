using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SpwanEnemies : MonoBehaviour
{
    /************MANAGER************/

    //[SerializeField] private float spwanRadius = 100f;
    [System.Serializable]
    private class Wave
    {
        public Wave(string name, Transform enemy, float rate, int count)
        {
            this.name = name;
            this.enemy = enemy;
            this.rate = rate;
            this.count = count;
        }

        public string name;
        public Transform enemy;
        public float rate;
        public int count;
    }
    private enum spawnState { Spawing, Waiting, Counting };

    private Wave[] waves;
    private Transform[] spawnPoints;

    public Transform Enemy;

    private int nextWave = 0;
    private float timeWithinWaves = 3.5f;
    public float waveCountDown;

    private spawnState state;
    private float checkEnemyTime = 1f;

    private Text Counter;


    // Start is called before the first frame update
    void Start()
    {
        waveCountDown = timeWithinWaves;
        state = spawnState.Counting;

        //Enemy = GameObject.Find("GreenGuy").transform;

        spawnPoints = new Transform[5];
        spawnPoints[0] = GameObject.Find("SpawnPointOne").transform;
        spawnPoints[1] = GameObject.Find("SpawnPointTwo").transform;
        spawnPoints[2] = GameObject.Find("SpawnPointThree").transform;

        spawnPoints[3] = GameObject.Find("SpawnPointFour").transform;
        spawnPoints[4] = GameObject.Find("SpawnPointFive").transform;


        waves = new Wave[10]; // fix transform
        waves[0] = new Wave("wave1", Enemy, 0.8f, 3);
        waves[1] = new Wave("wave2", Enemy, 0.9f, 5);
        waves[2] = new Wave("wave3", Enemy, 1.0f, 10);
        waves[3] = new Wave("wave4", Enemy, 1.0f, 12);
        waves[4] = new Wave("wave5", Enemy, 1.1f, 15);
        waves[5] = new Wave("wave6", Enemy, 1.2f, 20);
        waves[6] = new Wave("wave7", Enemy, 1.3f, 25);
        waves[7] = new Wave("wave8", Enemy, 1.3f, 25);
        waves[8] = new Wave("wave9", Enemy, 1.5f, 30);
        waves[9] = new Wave("wave10", Enemy, 1.5f, 35);


        Counter = GameObject.Find("RoundNumber").GetComponent<Text>();
        Counter.text = (1+nextWave).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(state == spawnState.Waiting)
        {
            if (!isEnemyAlive())
            {
                NextRound();
                Counter.text = (1 + nextWave).ToString();
                return;
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0f)
        {
            if (state != spawnState.Spawing)
            {
                StartCoroutine(SpawnEnemyWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown = waveCountDown - Time.deltaTime;
        }
    }

    /************HELPER FUNCTIONS************/

    void NextRound()
    {
        state = spawnState.Counting;
        waveCountDown = timeWithinWaves;

        if( (nextWave + 1) >= waves.Length)
        {
            nextWave = 5; // loop rounf 5
        }
        else
        {
            nextWave = nextWave + 1;
        }
    }

    bool isEnemyAlive()
    {
        checkEnemyTime = checkEnemyTime - Time.deltaTime;
        if (checkEnemyTime <= 0f)
        {
            checkEnemyTime = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnEnemyWave(Wave _Wave)
    {
        state = spawnState.Spawing;

        for(int i =0; i< _Wave.count; i++)
        {
            SpawnEnemy(_Wave.enemy);
            yield return new WaitForSeconds(1f / _Wave.rate);
        }

        state = spawnState.Waiting;
        yield break;
    }

    void SpawnEnemy(Transform enemy)
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
    }
}
