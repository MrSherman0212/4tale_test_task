using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private float _time = 15;
    private float _remainingTime = 15;

    private IEnumerator _countTime;
    private MonoBehaviour _context;

    public event Action<float> HasBeenUpdated;
    public event Action TimeIsOver;

    public Timer(MonoBehaviour context) => _context = context;

    public void Set(int time)
    {
        _time = time;
        _remainingTime = time;
    }

    public void AddTime(float extraTime)
    {
        _remainingTime += extraTime;
        if (_remainingTime > _time)
            _remainingTime = _time;
    }

    public void StartCountingTime()
    {
        _countTime = CountTime();
        _context.StartCoroutine(_countTime);
    }

    public void StopCountingTime()
    {
        _countTime = CountTime();
        _context.StopCoroutine(_countTime);
    }

    IEnumerator CountTime()
    {
        while (_remainingTime >= 0)
        {
            _remainingTime -= Time.deltaTime;

            HasBeenUpdated?.Invoke(_remainingTime);

            yield return null;
        }
        TimeIsOver?.Invoke();
        StopCountingTime();
    }
}
