using UnityEngine;

public class UserInputExample01 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("������ �����");
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log($"�������������� ���. Value: {Input.GetAxis("Horizontal")}");
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            Debug.Log($"������������ ���. Value: {Input.GetAxis("Vertical")}");
        }
    }
}
