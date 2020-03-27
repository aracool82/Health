using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;

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
        int temp = 1;
        if (value < 0)
        {
            temp = -1;
            value *= temp;
        }

        StartCoroutine(ChangetHealth(value,temp));
    }
    
    public IEnumerator ChangetHealth(int value,int temp)
    {
        var wait = new WaitForSeconds(0.005f);
        int i = 0;
        while(i++ < value)
        {
            _slider.value += 1*temp;
            _fill.color = _gradient.Evaluate(_slider.normalizedValue);
            yield return wait;
        }
    }
}
