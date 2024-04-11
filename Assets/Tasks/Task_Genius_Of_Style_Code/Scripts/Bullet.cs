using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private static int ID = 0;

    private void Awake()
    {
        ID++;
        gameObject.name = $"Bullet {ID}";
    }
}