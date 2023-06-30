using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text _text;
    private Timer _timer;

    public void Inintialize(Timer timer)
    {
        _timer = timer;
        _gameOverPanel.SetActive(false);
    }

    public void CheckForWin(bool win)
    {
        if (win)
        {
            DoEnd("KRASAVCHIK");
        }
    }

    public void DoLose()
    {
        DoEnd("LOSER");
    }

    public void DoEnd(string str)
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
        _text.text = str;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
