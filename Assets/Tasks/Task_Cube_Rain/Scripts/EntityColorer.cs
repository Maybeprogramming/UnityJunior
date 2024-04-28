using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(CollisionDetector))]
public class EntityColorer : MonoBehaviour
{
    private MeshRenderer _renderer;
    private CollisionDetector _colisionDetector;
    private bool _canColorIt;
    private Color _defaultColor = Color.red;

    private void Awake()
    {
        _colisionDetector = GetComponent<CollisionDetector>();
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material.color = _defaultColor;
        _canColorIt = true;
    }

    private void OnEnable()
    {
        _colisionDetector.collisionDetected += OnPaint;
    }

    private void OnDisable()
    {
        ResetByDefault();
        _colisionDetector.collisionDetected -= OnPaint;
    }

    private void ResetByDefault()
    {
        _renderer.material.color = _defaultColor;
        _canColorIt = true;
    }

    private void OnPaint()
    {
        if (_canColorIt == false)
            return;

        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
        _canColorIt = false;
    }
}