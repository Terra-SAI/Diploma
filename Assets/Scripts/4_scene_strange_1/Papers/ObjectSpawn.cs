using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{


    [SerializeField] private GameObject[] objectPrefabs; // Массив префабов объектов
    [SerializeField] private int totalObjects = 24; // Общее количество объектов
    [SerializeField] private Transform centralObject; // Центральный объект для размещения
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(10, 10); // Размер области размещения объектов
    [SerializeField] private float minZHeight = -5f; // Минимальная высота по оси Z
    [SerializeField] private float maxZHeight = 0f; // Максимальная высота по оси Z
    [SerializeField] private GameObject hiddenObject; // Объект, который становится видимым по завершении игры
    [SerializeField] private GameObject button;

     private List<GameObject> spawnedObjects = new List<GameObject>();
    private GameObject selectedObject = null; // Переменная для хранения первого выбранного объекта

    public bool isPaired = false;
    void Start()
    {
        isPaired = false;
        hiddenObject.SetActive(false);
        SpawnObjects();
    }

    void SpawnObjects()
    {
        float currentZHeight = maxZHeight;
        float objectGap = (maxZHeight - minZHeight) / totalObjects; // Расчет промежутка между объектами

        int objectTypes = objectPrefabs.Length;
        int objectsPerType = totalObjects / objectTypes;

        // Гарантируем, что количество объектов каждого типа будет четным
        objectsPerType += objectsPerType % 2;

        for (int i = 0; i < objectTypes; i++)
        {
            for (int j = 0; j < objectsPerType; j++)
            {
                Vector3 randomPosition = new Vector3(
                    centralObject.position.x + Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                    centralObject.position.y + Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                    currentZHeight
                );


                GameObject newObject = Instantiate(
                    objectPrefabs[i],
                    randomPosition,
                    Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)) // Случайный поворот
                    );

                var objectBounds = newObject.GetComponent<Renderer>().bounds;
                float objectHeight = objectBounds.size.z;

                // Устанавливаем финальную высоту с учетом высоты объекта
                newObject.transform.position = new Vector3(
                    newObject.transform.position.x,
                    newObject.transform.position.y,
                    Mathf.Clamp(currentZHeight - (objectHeight / 2), minZHeight, maxZHeight)
                );

                currentZHeight -= objectHeight + objectGap; // Уменьшаем текущую высоту на высоту объекта и промежуток

                // Убедитесь, что объект имеет коллайдер
                if (newObject.GetComponent<Collider>() == null)
                {
                    newObject.AddComponent<BoxCollider>();
                }

                newObject.AddComponent<MouseClick>().objectSpawner = this; // Связь с ObjectSpawner
                spawnedObjects.Add(newObject);
            }
        }
    }

    // Функция для проверки пар
    public void CheckPairs(GameObject objectA, GameObject objectB)
    {
        if (objectA.transform.GetComponent<Renderer>().material.color == objectB.transform.GetComponent<Renderer>().material.color)
        {
            Destroy(objectA);
            Destroy(objectB);
            spawnedObjects.Remove(objectA);
            spawnedObjects.Remove(objectB);

            if (spawnedObjects.Count == 0)
            {
                Debug.Log("Все объекты собраны! Игра завершена.");
                isPaired = true;
                hiddenObject.SetActive(true); // Показать объект по завершении игры

            }
        }
        else
        {
            // Если объекты не совпадают, снимаем выделение
            objectA.GetComponent<MouseClick>().ResetColor();
            objectB.GetComponent<MouseClick>().ResetColor();
        }
    }

    // Функция для обработки выбора объектов
    public void SelectObject(GameObject clickedObject)
    {
        if (selectedObject == null)
        {
            selectedObject = clickedObject;
        }
        else if (selectedObject == clickedObject)
        {
            // Если объект уже выбран, ничего не делаем
            selectedObject.GetComponent<MouseClick>().ResetColor();
            selectedObject = null;
        }
        else
        {
            CheckPairs(selectedObject, clickedObject);
            selectedObject = null; // Сброс выбора после проверки
        }
    }
}
public class MouseClick : MonoBehaviour
{
    public ObjectSpawner objectSpawner; // Ссылка на ObjectSpawner
    private Renderer objectRenderer;
    private Color originalColor;
    private Material objectMaterial;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
        objectMaterial = objectRenderer.material;
    }

    void OnMouseDown()
    {
        if (!objectMaterial.IsKeywordEnabled("_EMISSION"))
        {
            // Включение свечения
            objectMaterial.EnableKeyword("_EMISSION");
            objectMaterial.SetColor("_EmissionColor", Color.white);
            objectSpawner.SelectObject(gameObject); // Уведомление ObjectSpawner о клике
        }
        else
        {
            // Отключение свечения
            objectMaterial.DisableKeyword("_EMISSION");
            objectMaterial.SetColor("_EmissionColor", Color.black);
        }
    }

    public void ResetColor()
    {
        objectMaterial.DisableKeyword("_EMISSION");
        objectMaterial.SetColor("_EmissionColor", Color.black);
    }
}
