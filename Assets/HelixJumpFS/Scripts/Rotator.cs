using UnityEngine;

public class Rotator : MonoBehaviour
{
    #region mouseInput
    [SerializeField] private float _mouseSensetive = 2;
    [SerializeField] private string _mouseAxis = "Mouse X";
    #endregion

    #region keyboardInput
    //[SerializeField] float _rotationDegrees = 10f;  // ���������� �������� ��� ��������
    //private float _secondsToRotate = 1f;   // ����� ��� �������� �� �������� �������
    [SerializeField] private float _rotationSpeed = 20;
    [SerializeField] private string _keyboardAxis = "Horizontal";
    #endregion

    void Start()
    {
        //_rotationSpeed = _rotationDegrees / _secondsToRotate;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            transform.Rotate(0, Input.GetAxis(_mouseAxis) * -_mouseSensetive, 0);
        }


        float rotationInput = 0;

        if (Input.GetButton(_keyboardAxis))
        {
            rotationInput = Input.GetAxis(_keyboardAxis); // ������� ������
            //rotationInput = -_rotationDegrees; // ������� ������ - ���� ��������� �������� ������ ����������
        }

        if (rotationInput != 0)
        {
            // ���������� �������� ����
            float targetAngle = transform.eulerAngles.y + rotationInput;

            // ������� ������� � �������� ����
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * 10.0f * Time.deltaTime);
        }
    }
}

/*
����� vs. ��������: transform.Rotate() � ��� �����, ������� �������� ������� ��������, � transform.rotation � ��� ��������, ������� ������ ���������� ��������.

������������� vs. ����������: transform.Rotate() ������� ������ ������������ ��� �������� ���������, ����� ��� transform.rotation ������������� ���������� ��������.

����������: ��� ������������� transform.Rotate() �������� �������������, � �� ����� ��� ��� ��������� transform.rotation ����� �������� ���������� ��������, �������
�������� �������.
*/