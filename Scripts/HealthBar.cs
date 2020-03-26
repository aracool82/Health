using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] Gradient _gradient;
    [SerializeField] Image _fill;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _gradient.Evaluate(1f);
    }

    public void SetHealth(int value)
    {
        _slider.value += value;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
