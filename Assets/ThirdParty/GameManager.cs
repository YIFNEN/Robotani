using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameTime = 20f;        // 타이머 20초
    public int score = 0;               // 현재 점수
    public int killScore = 10;          // 적 처치 점수
    public int damageScore = -3;        // 적 충돌 감점

    private float currentTime;          //남은 시간
    private bool isGameRunning = false; //게임 진행 여부

    //씬 이름(Build Settings에서의 순서와 일치해야 함)
    private const string MAIN_SCENE = "Main";
    private const string GAME_SCENE = "gameTest";
    private const string GAMEOVER_SCENE = "GameOver";

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentTime = gameTime;

        // Game 씬일 때만 타이머 시작
        if (SceneManager.GetActiveScene().name == GAME_SCENE)
        {
            isGameRunning = true;
            score = 0;
            UpdateUI();
        }


    }

    void Update()
    {
        if (!isGameRunning) return;

        // 타이머 카운트다운
        currentTime -= Time.deltaTime;
        UIManager.Instance?.UpdateTimerUI(currentTime);

        // 타이머 종료 → Game Over scene 이동
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            GameOver();
        }
    }


    //main-> game scene(btn클릭)
    public void StartGame()
    {
        SceneManager.LoadScene(GAME_SCENE);

    }

    //game-> main scene(btn클릭)
    public void GoToMain()
    {
        isGameRunning = false;
        SceneManager.LoadScene(MAIN_SCENE);
    }

    //gameover scene 호출(타이머 종료)
    public void GameOver()
    {
        isGameRunning = false;

        //score 저장
        PlayerPrefs.SetInt("FinalScore", score);
        SceneManager.LoadScene(GAMEOVER_SCENE);
    }

    //다시하기(restart btn)
    public void Retry()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    //********* 점수 ************************

    public void AddKillScore()
    {
        score += killScore;
        UIManager.Instance?.UpdateScoreUI(score);
    }

    public void AddDamageScore()
    {
        score += damageScore;
        UIManager.Instance?.UpdateScoreUI(score);
    }

    void UpdateUI()
    {
        UIManager.Instance?.UpdateScoreUI(score);
        UIManager.Instance?.UpdateTimerUI(currentTime);
    }
}
