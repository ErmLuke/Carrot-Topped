using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float spawnTime;
    public float randomSpawnTime;
    public float realTime;
    public int wave;
    public float difficultyIncrease;
    public float maxDifficultyIncreaseGap;
    public float whenToSpawn = 1f;
    public int whatToSpawn;
    public float obstacleSpawnPointx;
    public float obstacleSpawnPointz;
    public float obstacleSpawnPointy;
    public float oSPZmin;
    public float oSPZmax;
    public float oSPXmin;
    public float oSPXmax;
    public float realSpawnTime;
    public List<GameObject> obstacles = new List<GameObject>();
    public float randomWaitTime;
    public int finalWave;
    public Transform Target;
    public float randomFrequency;

    // Start is called before the first frame update
    void Start()
    {
        finalWave = obstacles.Count-1;
    }

    // Update is called once per frame
    void Update()
    {
        randomWaitTime += Time.deltaTime;

        realTime += Time.deltaTime;


        if (randomWaitTime > randomFrequency)
        {
            randomWaitTime = 0;
            spawnTime = Random.Range(0f, difficultyIncrease);
            realSpawnTime = Mathf.Floor(spawnTime);
        }


        if (wave < finalWave)
        {
            whatToSpawn = Random.Range(0, wave);
        }
        else
        {
            whatToSpawn = Random.Range(0, finalWave);
        }

        obstacleSpawnPointz = Random.Range(oSPZmin, oSPZmax);

        if (realTime > difficultyIncrease)
        {
            realTime = 0f;
            wave += 1;

            if (randomFrequency > 0.2f)
            {
                randomFrequency -= 0.05f;
            }
            else
            {
                return;
            }
            if (difficultyIncrease > maxDifficultyIncreaseGap)
            {
                difficultyIncrease -= 0.5f;
            }
        }


        if (whenToSpawn == realSpawnTime)
        {
            Instantiate(obstacles[whatToSpawn], new Vector3(Target.position.x + obstacleSpawnPointx, obstacleSpawnPointy, obstacleSpawnPointz), Quaternion.identity);
            realSpawnTime = 999;
        }

    }

}
