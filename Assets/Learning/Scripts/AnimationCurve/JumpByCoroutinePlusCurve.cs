using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpByCoroutinePlusCurve : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _currentTime;
    [SerializeField] private float _totalTime;
    [SerializeField] private bool _isJump;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _isGroundedTransformPoint;
    [SerializeField] private int _jumpForce2;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _totalTime = _jumpCurve.keys[_jumpCurve.length - 1].time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            StartCoroutine(nameof(Jumper));
        }

        //_isJump = IsGrounded();

        //if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        //{
        //    _isJump = true;
        //    _playerRigidbody.AddForce(Vector3.up * _jumpForce);
        //}
    }

    private bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(_isGroundedTransformPoint.position, 0.1f);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Ground ground) == true)
            {
                return true;
            }
        }

        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        StopCoroutine(nameof(Jumper));
        ResetTime();
    }

    private IEnumerator Jumper()
    {
        float currentPositionY = transform.position.y;
        float nextPositionY;

        while (_currentTime <= _totalTime)
        {
            _currentTime += Time.deltaTime;

            nextPositionY = _jumpCurve.Evaluate(_currentTime);
            //nextPositionY = currentPositionY + _jumpCurve.Evaluate(_currentTime);

            //Через риджидбади не очень рабочая схема!
            //_playerRigidbody.Move(new Vector3(transform.position.x, nextPositionY, transform.position.z), Quaternion.identity);
            _playerRigidbody.velocity = new Vector3(0f, nextPositionY, 0f) * _jumpForce2;
           //transform.position = new Vector3(transform.position.x, nextPositionY, transform.position.z);

            yield return null;
        }

        ResetTime();
        StopCoroutine(nameof(Jumper));
    }

    private void ResetTime()
    {
        _currentTime = 0;
    }
}