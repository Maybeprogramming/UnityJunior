using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorSetter : MonoBehaviour
{
    [SerializeField] private int _minColorAmount;
    [SerializeField] private int _maxColorAmount;

    private System.Random _random;
    private MeshRenderer _renderer;
    private float _multiplier = 0.01f;

    void Start()
    {
        _random = new System.Random();
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material.color = GenerateColor();
    }

    private Color GenerateColor()
    {
        Color color = new Color();

        color.r = GetRandomValue();
        color.g = GetRandomValue();
        color.b = GetRandomValue();

        return color;
    }

    private float GetRandomValue()
    {
        return _random.Next(_minColorAmount, ++_maxColorAmount) * _multiplier;
    }
}
