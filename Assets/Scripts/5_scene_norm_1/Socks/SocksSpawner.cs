using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SocksSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sockPrefab;
    [SerializeField] private int totalSocks = 6;
    [SerializeField] private Color targetColor;
    [SerializeField] private Vector2 spawnAreaMin;
    [SerializeField] private Vector2 spawnAreaMax;
    [SerializeField] private float spawnY = 0f;

    private List<GameObject> spawnedSocks = new List<GameObject>();

    void Start()
    {
        GenerateSocks();
    }

    void GenerateSocks()
    {
        // ќпредел€ем два случайных индекса дл€ правильных носков
        int firstCorrect = Random.Range(0, totalSocks);
        int secondCorrect;
        do
        {
            secondCorrect = Random.Range(0, totalSocks);
        } while (secondCorrect == firstCorrect);

        for (int i = 0; i < totalSocks; i++)
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                spawnY + Mathf.Pow((-1),i) * 1.5f,
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            // —лучайное вращение по оси Y (в плоскости XZ)
            float randomYRotation = Random.Range(0f, 360f);
            Quaternion randomRotation = Quaternion.Euler(90f, randomYRotation, 0f);

            //// ѕолучаем размер коллайдера из префаба
            //BoxCollider prefabCollider = sockPrefab.GetComponent<BoxCollider>();
            //Vector3 halfExtents = prefabCollider.size * 0.5f;
            //Quaternion rotation = Quaternion.Euler(90f, randomYRotation, 0f);
            ////int count = 2;
            ////while (count > 0)
            ////{
            ////    // ѕроверка на пересечение
            ////    if (Physics.CheckBox(spawnPos + prefabCollider.center, halfExtents, rotation))
            ////    {
            ////        i--; // пробуем снова
            ////        //continue;
            ////        break;
            ////    }
            ////    else count--;
            ////}
            ////ѕроверка на пересечение
            //if (Physics.CheckBox(spawnPos + prefabCollider.center, halfExtents, rotation))
            //{
            //    i--; // пробуем снова
            //    continue;
            //}
            ////Collider[] colliders = Physics.OverlapBox(spawnPos, halfExtents, rotation);
            ////if (colliders.Length > 0)
            ////{
            ////    i--; // пробуем снова
            ////    continue;
            ////}

            GameObject sock = Instantiate(sockPrefab, spawnPos, randomRotation, transform);

            Renderer sockRenderer = sock.GetComponentInChildren<Renderer>();
            if (sockRenderer != null)
            {
                Color newColor = (i == firstCorrect || i == secondCorrect)
                    ? targetColor
                    : GetRandomColorDifferentFrom(targetColor);

                foreach (var mat in sockRenderer.materials)
                {
                    mat.color = newColor;
                }
            }

            spawnedSocks.Add(sock);
        }
    }

    Color GetRandomColorDifferentFrom(Color exclude)
    {
        Color newColor;
        do
        {
            newColor = new Color(Random.value, Random.value, Random.value);
        } while (ColorDistance(newColor, exclude) < 0.5f); // избегаем слишком похожих оттенков
        return newColor;
    }

    float ColorDistance(Color a, Color b)
    {
        float rDiff = a.r - b.r;
        float gDiff = a.g - b.g;
        float bDiff = a.b - b.b;
        return Mathf.Sqrt(rDiff * rDiff + gDiff * gDiff + bDiff * bDiff);
    }
}
