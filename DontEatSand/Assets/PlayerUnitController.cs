using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitController : MonoBehaviour
{


    Camera cam;
    RaycastHit hit;
    Vector3 mousePositon;
    List<UnitController> selectedUnits = new List<UnitController>();

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("RTSCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Detect mouse left click
        if (Input.GetMouseButtonDown(0))
        {
            mousePositon = Input.mousePosition;
            //Create a ray from the camera to the scene
            var camRay = cam.ScreenPointToRay(Input.mousePosition);
            //Shoot the ray
            if (Physics.Raycast(camRay, out hit))
            {
                if (hit.transform.CompareTag("target"))
                {
                    SelectUnit(hit.transform.GetComponent<UnitController>());
                }
                else
                {
                    DeselectUnits();
                }
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            mousePositon = Input.mousePosition;
            //Create a ray from the camera to the scene
            var camRay = cam.ScreenPointToRay(Input.mousePosition);
            //Shoot the ray
            if (Physics.Raycast(camRay, out hit))
            {
                foreach(UnitController unit in selectedUnits)
                {
                    unit.MoveUnit(hit.point);
                }
            }

        }
    }

    private void SelectUnit(UnitController unit)
    {
        if (!selectedUnits.Contains(unit))
        {
            selectedUnits.Add(unit);
        }
        Debug.Log(selectedUnits.Count);
    }

    private void DeselectUnits()
    {
        selectedUnits.Clear();
    }
}
