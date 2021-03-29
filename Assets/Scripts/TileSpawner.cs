using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public List<GameObject> newTiles = new List<GameObject>();
    public GameObject spawnPoint;
    public int spawnType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            spawnType = Random.Range(0, newTiles.Count -1);
            Instantiate(newTiles[spawnType], spawnPoint.transform.position, spawnPoint.transform.rotation);
            Debug.Log("Tile Spawned");
            Destroy(gameObject);
        }
    }


}

