using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject[] uiObjects;
    [SerializeField] GameObject helpUI;
    public bool uiEnabled = true;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            uiEnabled = !uiEnabled;

            for (int i = 0; i < uiObjects.Length; i++)
            {
                uiObjects[i].SetActive(uiEnabled);
            }
        }

        helpUI.SetActive(Input.GetKey(KeyCode.U));
    }
}
