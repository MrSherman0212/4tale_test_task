using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private TimeBar _timeBar;
    [SerializeField] private ScoreBar _scoreBar;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private CoinSpawner _coinSpawner;

    [SerializeField] private int _maxScores = 10;
    [SerializeField] private int _maxTime = 15;
    [SerializeField] private int _extraTime = 5;
    private Timer _timer;
    private ScoreCounter _scoreCounter;

    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        Time.timeScale = 1;
        _timer = new Timer(this);
        _timeBar?.Initialize(_timer);
        _timer.Set(_maxTime);
        _timer.StartCountingTime();

        _scoreCounter = new ScoreCounter(_maxScores);
        _scoreBar.Initialize(_scoreCounter);

        _gameManager.Inintialize(_timer);

        _playerController?.Initialize();
        _coinSpawner?.Initialize();
    }

    public void AddExtraTime() => _timer.AddTime(_extraTime);

    public void AddScore() => _scoreCounter.AddScore();

    public void CheckGameOver() => _gameManager.CheckForWin(_scoreCounter.CheckForWin());

    public void DoLose() => _gameManager.DoLose();

    private void OnEnable()
    {
        if (_timer != null)
            _timer.TimeIsOver += DoLose;
    }

    private void OnDisable()
    {
        if (_timer != null)
            _timer.TimeIsOver -= DoLose;
    }
}
