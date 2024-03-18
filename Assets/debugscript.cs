using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugscript : MonoBehaviour
{
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
    }
}
