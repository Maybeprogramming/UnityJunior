using UnityEngine;

public class _Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _wallPointChecker;
    [SerializeField] private int _isWall;

    private float _axisDirection;

    void Update()
    {
        _isWall = IsWallOnStraiht();

        Move();
        Flip();
    }

    private void Move()
    {
        _axisDirection = Input.GetAxis("Horizontal") * IsWallOnStraiht();

        if (Mathf.Abs(_axisDirection) > 0.1f)
        {
            transform.localPosition += Vector3.right * _axisDirection * _speed * Time.deltaTime;
        }
    }

    private int IsWallOnStraiht()
    {
        Collider[] walls = Physics.OverlapSphere(_wallPointChecker.transform.position, 0.1f);

        foreach (Collider wall in walls)
        {
            if(wall.TryGetComponent(out Ground ground))
            {
                return 0;
            }
        }

        return 1;
    }

    private void Flip()
    {
        if (_axisDirection < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (_axisDirection > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
