using UnityEngine;

public class InputKeyAndMouse : MonoBehaviour
{
    [SerializeField] private MeshRenderer _sphere;
    [SerializeField] private MeshRenderer _cube;
    [SerializeField] Color _colorSphereDef;
    [SerializeField] Color _colorCubeDef;
    
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    void Start()
    {
        _colorSphereDef = _sphere.material.GetColor("_Color");
        _colorCubeDef = _cube.material.GetColor("_Color");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log($"Нажата клавиша 1");
            _sphere.material.SetColor("_Color", Color.cyan);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            _sphere.material.SetColor("_Color", _colorSphereDef);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log($"Нажата и удерживается клавиша 2");
            _cube.material.SetColor("_Color", Color.cyan);
            _player.transform.position = _player.transform.position + _player.forward * Time.deltaTime * _speed;
        }
        else
        {
            _cube.material.SetColor("_Color", _colorCubeDef);
            _player.transform.position = _player.transform.position - _player.forward * Time.deltaTime * _speed;
        }
    }
}
