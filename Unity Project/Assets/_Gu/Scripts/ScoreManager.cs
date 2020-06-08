using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private void Awake() => instance = this;

    public Text scoreTxt;
    public Text highScoreTxt;
    public TextMeshProUGUI textTxt;

    int score = 0;
    int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreTxt.text = "HighScore : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        //하이스코어 
        saveHighScore();
    }

    private void saveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreTxt.text = "High Score : " + highScore;
        }
    }

    //점수 추가 및 텍스트 업데이트
    public void AddScore()
    {
        score++;
        scoreTxt.text = "Score : " + score;

        textTxt.text = "test...";
    }
}
