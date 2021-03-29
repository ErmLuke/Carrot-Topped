using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject resumePanel;
    public GameObject pauseScreen;
    public Camera menuCam;
    private Animator animCam;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        animCam = menuCam.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PauseOn()
    {
        Time.timeScale = 0;
        resumePanel.SetActive(true);
        pausePanel.SetActive(false);
        pauseScreen.SetActive(true);
        player.SetActive(false);
    }
    public void PauseOff()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(true);
        resumePanel.SetActive(false);
        pauseScreen.SetActive(false);
        player.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("PlayScene");
        Time.timeScale = 1;

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void PlayGame()
    {
        Restart();
    }

    public void menuLeaderboard()
    {
        animCam.Play("CamToLeaderboard");
    }

    public void leaderboardToMenu()
    {

        animCam.Play("LeaderboardToMenu");
    }

    public void menuCredits()
    {
        animCam.Play("CamToCredit");
    }

    public void creditsToMenu()
    {
        animCam.Play("CreditToMenu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitted");
    }
}
