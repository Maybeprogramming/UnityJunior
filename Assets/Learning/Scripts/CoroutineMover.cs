using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoroutineMover : MonoBehaviour
{
    [SerializeField] private List<Vector3> points;
    [SerializeField] private bool _isLoop;
    [SerializeField] private float _speed;

    private void Start()
    {
        _isLoop = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(Mover(points));
            Debug.Log("Нажата кнопка G");
        }
    }

    IEnumerator Mover(List<Vector3> points)
    {
        do
        {
            for (int i = 0; i < points.Count; i++)
            {
                while ((points[i] - transform.position).magnitude > 0.05f)
                {
                    var nextPosition = (points[i] - transform.position).normalized * Time.deltaTime * _speed;
                    transform.Translate(nextPosition);
                    yield return null;
                }
            }
        }
        while (_isLoop == true);
    }
}

