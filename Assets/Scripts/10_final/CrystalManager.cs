using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    [Space] public InventoryManager inventoryManager;
    [SerializeField] private List<int> requiredItemIds = new List<int> { 101, 102, 103, 104 };

    [Space]
    [SerializeField] private GameObject altar;

    private void Start()
    {
        Renderer renderer = altar.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material mat = renderer.material;
            mat.EnableKeyword("_EMISSION");
          //  mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
          //  mat.SetColor("_EmissionColor", Color.black);
        }
    }

    private void Update()
    {
        if (inventoryManager.HasItemsWithIds(requiredItemIds))
        {
            Renderer renderer = altar.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material mat = renderer.material;
                mat.DisableKeyword("_EMISSION");
                mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                mat.SetColor("_EmissionColor", Color.black);
            }
        }
    }
}
