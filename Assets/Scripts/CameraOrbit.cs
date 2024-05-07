using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // Об'єкт, навколо якого буде обертатися камера
    public float distance = 5.0f; // Відстань від камери до цільового об'єкта
    public float rotationSpeed = 5.0f; // Швидкість обертання камери
    
    [SerializeField]
    private Camera _cam;
    private float _currentX = 0.0f;
    private float _currentY = 0.0f;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned to CameraOrbit script!");
            enabled = false; // Вимикаємо скрипт, якщо не призначений об'єкт
        }
        if(_cam != null)
        _cam= GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Отримуємо значення осей від введення користувача
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            _currentX += mouseX;
            _currentY -= mouseY;

            // Клампуємо кут Y, щоб камера не змінювала положення під дивом вгору чи вниз
            _currentY = Mathf.Clamp(_currentY, -90f, 90f);

            // Обчислюємо поворот камери
            Quaternion rotation = Quaternion.Euler(_currentY, _currentX, 0);

            // Оновлюємо позицію камери, щоб вона завжди знаходилася на відстані distance від цільового об'єкта
            transform.position = target.position - rotation * Vector3.forward * distance;

            // Напрямок камери завжди спрямований на цільовий об'єкт
            transform.LookAt(target.position);
        }
    }
}