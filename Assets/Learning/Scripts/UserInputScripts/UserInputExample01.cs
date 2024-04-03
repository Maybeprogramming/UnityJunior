using UnityEngine;

public class UserInputExample01 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Пробел нажат");
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log($"Горизонтальная Ось. Value: {Input.GetAxis("Horizontal")}");
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            Debug.Log($"Вертикальная Ось. Value: {Input.GetAxis("Vertical")}");
        }
    }
}
