using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ColorTransition : GameAction
{
    [SerializeField] private Graphic _target;
    [SerializeField] private AnimationCurve _function;
    [SerializeField] private float _duration;

    [Tooltip("Determines whether to take the starting or ending color from the source")]
    [SerializeField] private ColorBinding _colorBinding;

    private Color _startColor;
    private Color _endColor;

    private void Awake()
    {
        if (_target == null) return;
        _startColor = _target.color;
    }

    public override IEnumerator Invoke()
    {
        for (float i = 0; i < 1; i += Time.deltaTime / _duration)
        {
            _target.color = Color.Lerp(_startColor, Color.clear, _function.Evaluate(i));
            yield return null;
        }
        _target.color = Color.clear;
    }

    /// <summary>
    /// Определяет, следует ли брать начальный или конечный цвет из источника
    /// </summary>
    public enum ColorBinding
    {
        None, // не брать
        Start, // взять начальный цвет
        End // взять конечный цвет
    }
}