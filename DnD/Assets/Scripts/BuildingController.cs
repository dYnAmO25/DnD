using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingController : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject setText;
    [SerializeField] GameObject hotBar;
    [SerializeField] int maxBuildingLevel;
    [HideInInspector] public GameObject[] ghostBuildings;
    [HideInInspector] public GameObject[] prefabBuildings;
    public int selectedItem = -1;
    private float buildingRotation = 0;
    public bool buildingMode = false;
    private int buildingLevel = 0;

    private const int buildingHeight = 2;


    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        if (buildingRotation == 360) { buildingRotation = 0; }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            buildingMode = !buildingMode;
            text.text = "Building-Mode: " + buildingMode.ToString();
            setText.SetActive(buildingMode);
            hotBar.SetActive(buildingMode);
        }

        if (buildingMode == true)
        {
            GetSelectedItem();
            PlaceBuilding();
            DeleteBuilding();
            UpdateBuildingLevel();

            if (Input.GetKeyDown(KeyCode.R))
            {
                buildingRotation += 90;
            }
        }

        SetGhosts();
    }

    void UpdateBuildingLevel()
    {
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            if (buildingLevel < maxBuildingLevel)
            {
                buildingLevel++;
            }
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            if (buildingLevel > 0)
            {
                buildingLevel--;
            }
        }
    }

    void DeleteBuilding()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Wall" || hit.collider.tag == "WallWindow" || hit.collider.tag == "Pillar")
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    void PlaceBuilding()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(prefabBuildings[selectedItem], new Vector3(Mathf.FloorToInt(gridManager.hit.point.x) + 0.5f, buildingLevel * buildingHeight, Mathf.FloorToInt(gridManager.hit.point.z) + 0.5f), Quaternion.Euler(new Vector3(0, buildingRotation, 0)));
        }
    }

    void GetSelectedItem()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedItem = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedItem = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedItem = 2;
        }
    }

    void SetGhosts()
    {
        if (buildingMode)
        {
            ghostBuildings[selectedItem].transform.position = new Vector3(Mathf.FloorToInt(gridManager.hit.point.x) + 0.5f, buildingLevel * buildingHeight, Mathf.FloorToInt(gridManager.hit.point.z) + 0.5f);
            ghostBuildings[selectedItem].transform.rotation = Quaternion.Euler(new Vector3(0, buildingRotation, 0));

            for (int i = 0; i < ghostBuildings.Length; i++)
            {
                if (i != selectedItem)
                {
                    ghostBuildings[i].transform.position = new Vector3(-90, 0, 0);
                }
            }
        }
        else
        {
            for (int i = 0; i < ghostBuildings.Length; i++)
            {
                ghostBuildings[i].transform.position = new Vector3(-90, 0, 0);
            }
        }
    }
}
