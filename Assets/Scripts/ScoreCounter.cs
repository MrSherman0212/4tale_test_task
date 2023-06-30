using System;
using UnityEngine.Events;

public class ScoreCounter
{
    private int _maxScore = 15;
    private int _scores = 0;

    public int MaxScores { get { return _maxScore; } }
    public int Scores { get { return _scores; } }

    public ScoreCounter(int maxScore) => _maxScore = maxScore;

    public void AddScore() => _scores++;

    public bool CheckForWin() => _maxScore == _scores;
}
