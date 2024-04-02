using UnityEngine;

public class EnableHitPoint : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;

    private void Awake()
    {
        _sphere.SetActive(true);
    }
}
