using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessagePrinter : MonoBehaviour
{
    [SerializeField] private RayCastInfo _hitPosition;
    [SerializeField] private TextMeshProUGUI _text;
    [Header("¬ведите текст:")]
    [SerializeField] private string _startMessage;
    [SerializeField] private string _nonModifyText;
    [SerializeField] private string _modifyText;
    [SerializeField] private bool modifyTrigger;

    void Start()
    {
        _text.text = _startMessage;
    }

    private void PrintModifyText(Vector3 point)
    {
        _text.text = _nonModifyText;
    }

    private void PrintText(Vector3 point)
    {
        _text.text = _modifyText;
    }

    private void OnEnable()
    {
        _hitPosition.OnPointModifyClicked += PrintModifyText;
        _hitPosition.OnPointCliked += PrintText;
    }

    private void OnDisable()
    {
        _hitPosition.OnPointCliked += PrintText;
        _hitPosition.OnPointModifyClicked -= PrintModifyText;
    }
}
