using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;          
    [SerializeField] private Transform spawnPoint;           
    [SerializeField] private float spawnRate = 0.05f;        
    [SerializeField] private GameObject foodCamera;          
    [SerializeField] private float minX = -5f;               
    [SerializeField] private float maxX = 5f;                
    [SerializeField] private float minY = 2f;                
    [SerializeField] private float maxY = 8f;                

    private bool isPouring = false;
    private Coroutine pouringCoroutine;
    private Quaternion spawnRotation;
    private Quaternion prefabRotation;

    private void Start()
    {
        spawnRotation = this.transform.rotation;
        prefabRotation = foodPrefab.transform.rotation;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        // рассчитываем Z как расстояние между камерой и пакетом
        float distanceFromCamera = Mathf.Abs(foodCamera.transform.position.z - transform.position.z);
        mousePos.z = distanceFromCamera;

        Vector3 worldPos = foodCamera.GetComponent<Camera>().ScreenToWorldPoint(mousePos);

        // ограничиваем координаты по X и Y
        float clampedX = Mathf.Clamp(worldPos.x, minX, maxX);
        float clampedY = Mathf.Clamp(worldPos.y, minY, maxY);

        // обновляем только X и Y, чтобы Z остался прежним
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        // Начать сыпать
        if (Input.GetMouseButtonDown(0))
        {
            isPouring = true;
            pouringCoroutine = StartCoroutine(SpawnFood());
            transform.rotation = Quaternion.Euler(spawnRotation.eulerAngles.x, spawnRotation.eulerAngles.y, 50f);
        }

        // Прекратить сыпать
        if (Input.GetMouseButtonUp(0))
        {
            isPouring = false;
            if (pouringCoroutine != null)
                StopCoroutine(pouringCoroutine);
            transform.rotation = spawnRotation;
        }
    }

    private IEnumerator SpawnFood()
    {
        while (isPouring)
        {
            Instantiate(foodPrefab, spawnPoint.position, prefabRotation);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
