using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    static int ID = 0;

    private void Awake()
    {
        ID++;
        gameObject.name = ID.ToString();
    }
}