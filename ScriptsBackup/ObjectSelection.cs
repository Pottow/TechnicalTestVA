using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
            if (!EventSystem.current.IsPointerOverGameObject()){
                DeselectObjectForReselection();
                SelectObject(objectClicked);
            }
        }
        else if (!EventSystem.current.IsPointerOverGameObject()){
            DeselectObject();
        }
    }

    public void HighlightSelectedObject(GameObject objectSelected){
        objectSelected.GetComponent<Renderer>().material.color = Color.yellow; 
    }

    public void SelectObject(GameObject objSelectedOrCreated){
        selectedObject = objSelectedOrCreated;
        HighlightSelectedObject(selectedObject);
        GetComponent<ObjectMovement>().mainObject = selectedObject;
        GetComponent<ObjectRotation>().mainObjectRotation = selectedObject;
        GetComponent<CameraMovement>().CameraMoveOff();
        GetComponent<ObjectModification>().ShowModifiers();
        isSelectedObject = true;

        previousSelectedObject = selectedObject;
    }

    public void DehighlightSelectedObject(){
        if (previousSelectedObject != null){
            previousSelectedObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void DeselectObjectForReselection(){
        if (previousSelectedObject != null){
            DehighlightSelectedObject ();
        }
        isSelectedObject = false;
    }

    public void DeselectObject(){
        DeselectObjectForReselection();
        GetComponent<ObjectModification>().HideModifiers();
        GetComponent<CameraMovement>().CameraMoveOn();

    }
}
