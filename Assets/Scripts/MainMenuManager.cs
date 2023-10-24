using System.Collections;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;

    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _speedCurve;

    private void Awake()
    {
        _highScoreText.text = GameManager.Instance.HighScore.ToString();
        StartCoroutine(ShowScore());
    }

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        _scoreText.text = tempScore.ToString();

        int currentScore = GameManager.Instance.CurrentScore;
        Events.HighScoreUpdate?.Invoke(currentScore);

        float speed = 1 / _animationTime;
        float timeElapsed = 0f;
        while(timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;

            tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);
            _scoreText.text = tempScore.ToString();

            yield return null;
        }

        tempScore = currentScore;
        _scoreText.text = tempScore.ToString();
    }

}
