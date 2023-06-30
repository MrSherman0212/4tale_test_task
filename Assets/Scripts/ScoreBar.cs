using UnityEngine;
using TMPro;

public class ScoreBar : MonoBehaviour
{
    private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _text;

    public void Initialize(ScoreCounter scoreCounter)
    {
        _scoreCounter = scoreCounter;

        UpdateValue();
    }

    public void UpdateValue()
    {
        string scoreText = _scoreCounter.Scores.ToString() + "/" + _scoreCounter.MaxScores.ToString();
        _text.text = scoreText;
    }
}
