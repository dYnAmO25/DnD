using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] BuildingController buildingController;
    [SerializeField] TMP_Text text;
    [SerializeField] Image[] hotbar;
    [Header("Stone Prefabs")]
    [SerializeField] GameObject[] prefabStones;
    [SerializeField] GameObject[] ghostStones;
    [SerializeField] Sprite[] spriteStones;
    [Header("Wood Prefabs")]
    [SerializeField] GameObject[] prefabWood;
    [SerializeField] GameObject[] ghostWood;
    [SerializeField] Sprite[] spriteWood;

    void Start()
    {
        
    }

    void Update()
    {
        UpdateSelection();
    }

    void UpdateSelection()
    {
        if (buildingController.buildingMode)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                buildingController.prefabBuildings = prefabStones;
                buildingController.ghostBuildings = ghostStones;
                text.text = "Selected Set: Stone";
                for (int i = 0; i < spriteStones.Length; i++)
                {
                    hotbar[i].sprite = spriteStones[i];
                }
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                buildingController.prefabBuildings = prefabWood;
                buildingController.ghostBuildings = ghostWood;
                text.text = "Selected Set: Wood";
                for (int i = 0; i < spriteStones.Length; i++)
                {
                    hotbar[i].sprite = spriteWood[i];
                }
            }
        }
    }
}
