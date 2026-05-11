using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Game Scene UI")]
    public TextMeshProUGUI scoreText;          // TextMeshProUGUI → Text 로 변경
    public TextMeshProUGUI timerText;

    [Header("GameOver Scene UI")]
    public TextMeshProUGUI finalScoreText;

    // 나머지 코드는 동일

    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        // GameOver 씬이면 PlayerPrefs에서 직접 읽어옴
        if (finalScoreText != null)
        {
            int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
            finalScoreText.text = $"FINAL SCORE!: {finalScore}";
        }
    }


    public void UpdateScoreUI(int score)
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }

    public void UpdateTimerUI(float time)
    {
        if (timerText != null)
            timerText.text = $"Time: {Mathf.CeilToInt(time)}";  // 소수점 올림
    }

    // GameOver 씬 최종 점수 표시
    public void UpdateFinalScoreUI(int score)
    {
        if (finalScoreText != null)
            finalScoreText.text = $"FINAL SCORE!: {score}";
    }
}
