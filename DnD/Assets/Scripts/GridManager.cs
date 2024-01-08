using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Material gridMat;

    public bool enableGrid = true;

    public RaycastHit hit;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }


    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 v3 = new Vector3(Mathf.FloorToInt(hit.point.x) + 0.5f, 0.5f, Mathf.FloorToInt(hit.point.z) + 0.5f);
            if (v3.x > 0)
            {
                gridMat.SetInt("_SelectedCellX", (int)v3.x + 50);
            }
            else
            {
                gridMat.SetInt("_SelectedCellX", (int)v3.x + 49);
            }
            if (v3.z > 0)
            {
                gridMat.SetInt("_SelectedCellY", (int)v3.z + 50);

            }
            else
            {
                gridMat.SetInt("_SelectedCellY", (int)v3.z + 49);

            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            enableGrid = !enableGrid;

            gameObject.GetComponent<MeshRenderer>().enabled = enableGrid;
        }
    }
}
