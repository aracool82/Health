using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _gradient.Evaluate(1f);
    }

    public void StartChangetHealth(int value)
    {
        StartCoroutine(ChangetHealth(value));
    }
    
    public IEnumerator ChangetHealth(int value)
    {
        int addHealth = 1;
        if (value < 0)
        {
            addHealth = -1;
            value *= addHealth;
        }

        for (int i = 0; i < value; i++)
        {
            _slider.value += addHealth;
            _fill.color = _gradient.Evaluate(_slider.normalizedValue);
            yield return null;
        }
    }
}
