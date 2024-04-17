using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorSetter : MonoBehaviour
{
    private MeshRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material.color = new Color(Random.value,Random.value, Random.value);
    }
}
