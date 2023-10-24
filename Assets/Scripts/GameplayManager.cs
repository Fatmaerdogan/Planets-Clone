using System.Collections;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _scorePrefab;

    private int score;

    private void Awake()
    {
        score = 0;
        _scoreText.text = score.ToString();
        SpawnScore();
    }
    private void Start()
    {
        Events.GameEnded += GameEnded;
        Events.UpdateScore += UpdateScore;
    }
    private void OnDestroy()
    {
        Events.GameEnded -= GameEnded;
        Events.UpdateScore -= UpdateScore;
    }
    public void UpdateScore()
    {
        score++;
        _scoreText.text = score.ToString();
        SpawnScore();
    }

    private void SpawnScore()=>Instantiate(_scorePrefab);
    public void GameEnded()
    {
        Events.CurrentScoreUpdate?.Invoke(score);
        Events.GoToMainMenu?.Invoke();
    }

   
}
