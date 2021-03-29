using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{

    public bool hasStarted;
    public GameObject objectSpawner;
    public GameObject player;
    public GameObject faceMonster;
    public GameObject menuScreen;
    public PlayerController playerScript;
    public AudioSource playerSound;
    public AudioSource musicLoop;
    public bool isAndroid;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartGame");
        menuScreen.SetActive(false);
        musicLoop.volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                objectSpawner.SetActive(true);
                faceMonster.SetActive(true);
                playerScript.enabled = true;
                playerSound.enabled = true;
                musicLoop.pitch += 0.002f * Time.deltaTime;
            }
            else if (isAndroid)
            {
                objectSpawner.SetActive(true);
                faceMonster.SetActive(true);
                playerScript.enabled = true;
                playerSound.enabled = true;
                musicLoop.pitch += 0.002f * Time.deltaTime;
            }
        }
    }
    IEnumerator StartGame()
    {
        Time.timeScale = 1;
        player.SetActive(true);
        yield return new WaitForSeconds(3f);
        hasStarted = true;
    }
}
