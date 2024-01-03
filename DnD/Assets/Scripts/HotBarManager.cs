using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBarManager : MonoBehaviour
{
    [SerializeField] Color normalColor;
    [SerializeField] Color selectedColor;
    [SerializeField] BuildingController buildingController;
    [SerializeField] Image[] hotbarItems;

    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < hotbarItems.Length; i++)
        {
            if (i == buildingController.selectedItem)
            {
                hotbarItems[i].color = selectedColor;
            }
            else
            {
                hotbarItems[i].color = normalColor;
            }
        }
    }
}
