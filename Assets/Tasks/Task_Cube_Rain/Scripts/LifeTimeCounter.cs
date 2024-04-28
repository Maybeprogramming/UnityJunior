using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CollisionDetector))]
public class LifeTimeCounter : MonoBehaviour
{
    [SerializeField] private int _minLifeTimer;
    [SerializeField] private int _maxLifeTimer;

    private int _lifeTime;
    private CollisionDetector _colisionDetector;

    private void Awake()
    {
        _colisionDetector = GetComponent<CollisionDetector>();
    }

    private void Start()
    {
        _lifeTime = Random.Range(_minLifeTimer, ++_maxLifeTimer);
    }
    private void OnEnable()
    {
        _colisionDetector.collisionDetected += OnStartCountdown;
    }

    private void OnDisable()
    {
        _colisionDetector.collisionDetected -= OnStartCountdown;
    }

    private void OnStartCountdown()
    {
        StartCoroutine(LifeTime—ountdown());
    }

    private IEnumerator LifeTime—ountdown()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _lifeTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}