using UnityEngine;
using TMPro;

public class TimeBar : MonoBehaviour
{
    private Timer _timer;
    [SerializeField] private TMP_Text _text;

    public void Initialize(Timer timer) => _timer = timer;


    protected void OnValueChanged(float value)
    {
        float upRoundedValue = Mathf.Ceil(value);
        _text.text = upRoundedValue.ToString();
    }

    private void OnEnable()
    {
        if (_timer != null)
            _timer.HasBeenUpdated += OnValueChanged;
    }

    private void OnDisable()
    {
        if (_timer != null)
            _timer.HasBeenUpdated -= OnValueChanged;
    }
}
