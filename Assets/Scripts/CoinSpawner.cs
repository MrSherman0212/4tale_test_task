using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Transform[] _coinPositions;
    private Transform _coinPosHolder;
    [SerializeField] private GameObject _coin;

    private int _totalCoinPos = 0;
    [SerializeField] private int _lastCoinPos = -1;

    public void Initialize()
    {
        _coinPosHolder = GetComponent<Transform>();
        FillPosArray();
        _coin.SetActive(false);

        SpawnCoin();
    }

    private void FillPosArray()
    {
        _totalCoinPos = _coinPosHolder.transform.childCount;
        _coinPositions = new Transform[_totalCoinPos];
        for (int i = 0; i < _totalCoinPos; i++)
        {
            _coinPositions[i] = _coinPosHolder.transform.GetChild(i).transform;
        }
    }

    private List<int> ExcluseFromList()
    {
        List<int> positions = new List<int>();
        for (int i = 0; i < _totalCoinPos; i++)
        {
            if (i == _lastCoinPos)
            {
                positions.Remove(i);
                continue;
            }
            positions.Add(i);
        }

        return positions;
    }

    public int GetRandomFromRange()
    {
        int rand = Random.Range(0, _totalCoinPos - 1);
        return ExcluseFromList()[rand];
    }

    public void SpawnCoin()
    {
        int rand = GetRandomFromRange();
        _coin.transform.position = _coinPositions[rand].transform.position;
        _coin.SetActive(true);
        _lastCoinPos = rand;
    }
}
