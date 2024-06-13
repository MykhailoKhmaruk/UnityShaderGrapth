using UnityEngine;

public class GridInstantiator : MonoBehaviour
{
    // Префаб, який ми будемо інстанціювати
    public GameObject prefab;

    // Розмір сторони квадрату (кількість префабів по кожній стороні)
    public int size = 5;

    // Відстань між префабами по осях X і Y
    public float deltaX = 2.0f;
    public float deltaY = 2.0f;

    // Стартова позиція для інстанціювання
    public Vector3 startPosition = Vector3.zero;

    void Start()
    {
        InstantiateGrid();
    }

    void InstantiateGrid()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Vector3 position = startPosition + new Vector3(i * deltaX, j * deltaY, 0);
                Instantiate(prefab, position, Quaternion.identity);
            }
        }
    }
}
