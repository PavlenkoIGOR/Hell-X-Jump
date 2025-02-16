using UnityEngine;

public class Rotator : MonoBehaviour
{
    #region mouseInput
    [SerializeField] private float _mouseSensetive = 2;
    [SerializeField] private string _mouseAxis = "Mouse X";
    #endregion

    #region keyboardInput
    //[SerializeField] float _rotationDegrees = 10f;  // количество градусов дл€ поворота
    //private float _secondsToRotate = 1f;   // врем€ дл€ поворота на заданные градусы
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
            rotationInput = Input.GetAxis(_keyboardAxis); // ѕоворот вправо
            //rotationInput = -_rotationDegrees; // ѕоворот вправо - если конкретно задавать кнопки управлени€
        }

        if (rotationInput != 0)
        {
            // ¬ычисление целевого угла
            float targetAngle = transform.eulerAngles.y + rotationInput;

            // ѕлавный поворот к целевому углу
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * 10.0f * Time.deltaTime);
        }
    }
}

/*
ћетод vs. —войство: transform.Rotate() Ч это метод, который измен€ет текущее вращение, а transform.rotation Ч это свойство, которое задает конкретное вращение.

ќтносительное vs. јбсолютное: transform.Rotate() вращает объект относительно его текущего положени€, тогда как transform.rotation устанавливает абсолютное вращение.

Ќакопление: ѕри использовании transform.Rotate() вращение накапливаетс€, в то врем€ как при установке transform.rotation можно задавать конкретное значение, которое
замен€ет текущее.
*/