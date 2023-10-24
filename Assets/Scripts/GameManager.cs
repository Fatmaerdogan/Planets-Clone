using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()=>Instance = this;
    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt("HighScore", 0);
        }
        set
        {
            PlayerPrefs.SetInt("HighScore", value);
        }
    }
    private void Start()
    {
        Events.CurrentScoreUpdate += CurrentScoreUpdate;
        Events.HighScoreUpdate += HighScoreUpdate;
        Events.GoToMainMenu += GoToMainMenu;
    }
    private void OnDestroy()
    {
        Events.CurrentScoreUpdate -= CurrentScoreUpdate;
        Events.HighScoreUpdate -= HighScoreUpdate;
        Events.HighScoreUpdate -= HighScoreUpdate;
    }
    void CurrentScoreUpdate(int score) => CurrentScore = score;
    void HighScoreUpdate(int score)
    {
        if(HighScore<score) HighScore = score;
    }
    public int CurrentScore { get; set; }
    public void GoToMainMenu()=>SceneManager.LoadScene(0);
    public void GoToGameplay()=>SceneManager.LoadScene(1);

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.GoToMainMenu();
    }
}
