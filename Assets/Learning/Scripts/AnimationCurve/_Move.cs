using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Move : MonoBehaviour
{
    [SerializeField] private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float axisValue = Input.GetAxis("Horizontal");

        if (Mathf.Abs(axisValue) > 0.1f)
        {
            transform.localPosition += Vector3.right * axisValue * _speed * Time.deltaTime;
        }
    }
}
