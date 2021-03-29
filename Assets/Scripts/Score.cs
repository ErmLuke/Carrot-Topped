using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float score;
    public float maxScore;
    public GameObject HighScoreText;
    public GameObject ScoreText;
    public GameObject enterNewScore;
    public float highestScore;
    [SerializeField] GameObject player;
    Transform playerpos;
    float playerstart;
    string update;
    public TMP_InputField inputfield;
    public int newScore;
    public GameObject otherShit;
    public GameObject otherShitTwo;
    HighscoreScript hscript;
    string st = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    char randomC;
    char randomTwo;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        playerpos = player.GetComponent<Transform>();
        playerstart = playerpos.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        randomC = st[Random.Range(0,st.Length)];
        randomTwo = st[Random.Range(0, st.Length)];

        playerpos = player.GetComponent<Transform>();

        ScoreText.GetComponent<TextMeshProUGUI>().text = (score) + "M";

        highestScore = (PlayerPrefs.GetFloat("highscoress"));

        HighScoreText.GetComponent<TextMeshProUGUI>().text = ("High Score \n" + PlayerPrefs.GetFloat("highscoress"));

        if (playerpos.position.x <= score)
        {
            score = Mathf.Ceil(Mathf.Abs(playerpos.position.x - playerstart));
        }

        if (maxScore < score)
        {
            maxScore = score;
        }


        newScore = (int)maxScore;

    }
    public void onDeath()
    {

        if (score > highestScore)
        {
            enterNewScore.SetActive(true);
            highestScore = (score);
            PlayerPrefs.SetFloat("highscoress", highestScore);
            otherShit.SetActive(false);
            otherShitTwo.SetActive(false);
            HighScoreText.GetComponent<TextMeshProUGUI>().text = ("High Score" + PlayerPrefs.GetFloat("highscoress"));
        }
        PlayerPrefs.Save();
    }
    public void addScore()
    {
        HighscoreScript.AddNewHighscore(inputfield.text + randomC + randomTwo , newScore);
        enterNewScore.SetActive(false);

    }
}
