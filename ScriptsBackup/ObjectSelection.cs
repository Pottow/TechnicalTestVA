using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
     [System.NonSerialized]
    public GameObject selectedObject;
     [System.NonSerialized]
    public GameObject previousSelectedObject;
    [System.NonSerialized]
    public bool isSelectedObject = false;
    RaycastHit hit;
    Ray rayOrigin;
    Camera mainCamera;
    GameObject objectClicked;
    
    private void Start() {
        mainCamera = Camera.main;
    }
    
    public void ClickObject(){
        rayOrigin = mainCamera.ScreenPointToRay(Input.mousePosition); 
        if (Physics.Raycast (rayOrigin, out hit, 100)){
            objectClicked = hit.transform.gameObject;
            DeselectObject();
            SelectObject(objectClicked);
        }
        else{
            DeselectAllObject();
        }
    }

    public void HighlightSelectedObject(GameObject objectSelected){
        objectSelected.GetComponent<Renderer>().material.color = Color.yellow; 
    }

    public void SelectObject(GameObject objSelectedOrCreated){
        selectedObject = objSelectedOrCreated;
        HighlightSelectedObject(selectedObject);
        GetComponent<ObjectMovement>().mainObject = selectedObject;
        GetComponent<CameraMovement>().CameraMoveOff();
        isSelectedObject = true;

        previousSelectedObject = selectedObject;
    }

    public void DehighlightSelectedObject(){
        if (previousSelectedObject is not null){
            previousSelectedObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void DeselectObject(){
        if (previousSelectedObject is not null){
            DehighlightSelectedObject ();
        }
        isSelectedObject = false;
    }

    public void DeselectAllObject(){
        DeselectObject();
        GetComponent<CameraMovement>().CameraMoveOn();

    }
}
