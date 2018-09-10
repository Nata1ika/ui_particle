using UnityEngine;
using UnityEngine.UI;

public class SliderEffect : MonoBehaviour
{
    [SerializeField] Slider _slider;

    [SerializeField] ParticleSystem _up;
    [SerializeField] ScreenWorldPosition _upPos;

    [SerializeField] ParticleSystem _down;
    [SerializeField] ScreenWorldPosition _downPos;

    [SerializeField] Text _text;
    const int MAX = 1000;
    const float MAX_TIME = 3f;

    float _value;
    float _timeUp = -1f;
    float _timeDown = -1f;

    private void Start()
    {
        _value = _slider.value;
        int value = (int)(_value * MAX);
        _text.text = value.ToString();
    }

    public void OnValueChanged()
    {
        int value = (int)(_value * MAX);
        _text.text = value.ToString();

        if (_slider.value > _value)
        {
            _upPos.UpdatePosition();
            _timeUp = MAX_TIME;            
            _up.Play(true);

            _timeDown = -1f;
            _down.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        else
        {
            _downPos.UpdatePosition();            
            _timeDown = MAX_TIME;
            _down.Play(true);

            _timeUp = -1f;
            _up.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        _value = _slider.value;
    }

    private void Update()
    {
        if (_timeUp > 0)
        {
            _timeUp -= Time.deltaTime;
            if (_timeUp <= 0)
            {
                _up.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }

        if (_timeDown > 0)
        {
            _timeDown -= Time.deltaTime;
            if (_timeDown <= 0)
            {
                _down.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }
    }
}
