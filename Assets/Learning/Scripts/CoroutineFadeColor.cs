using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineFadeColor : MonoBehaviour
{
    [SerializeField] private float _speed;
    private MeshRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        Color green = _renderer.material.color;
        green.g = 1f;
        _renderer.material.color = green;
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Debug.Log("Нажата кнопка F");
            StartCoroutine(Fade());
        }
    }
    IEnumerator Fade()
    {
        Color c = _renderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.01f)
        {
            c.g = alpha;

            _renderer.material.color = c;
            //yield return null;
            yield return new WaitForSeconds(_speed * Time.deltaTime);
        }
    }
}
