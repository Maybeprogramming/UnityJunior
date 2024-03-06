using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmToDebag : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();

        if(player == null)
        {
            return;
        }

        Debug.Log(other.name + " вошёл в триггер");

        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetColor("_Color", Color.green);
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<Player>();

        if (player == null)
        {
            return;
        }

        Debug.Log(other.name + " вышел из триггера");

        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetColor("_Color", Color.red);
    }
}
