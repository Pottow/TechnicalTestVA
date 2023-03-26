using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectRotation : MonoBehaviour
{
     [System.NonSerialized]
    public bool toggleRotation;
     [System.NonSerialized]
    public GameObject mainObjectRotation;
    Quaternion currentObjRotation;
    float rotationSpeed = 100;
    float currentForwardRotation;
    Camera mainCamera;
    

    private void Start() {
        mainCamera = Camera.main;
    }

    public void ToggleRotation(){
        if (GetComponent<ObjectSelection>().isSelectedObject == true){
                toggleRotation = !toggleRotation;
                if (toggleRotation == true){
                    GetComponent<CameraMovement>().CameraMoveOff();
                }
        } 
    }

    public void ToggleRotationOff(){
        if (GetComponent<ObjectSelection>().isSelectedObject == true){
                toggleRotation = false;
        } 
    }

    public void ToggleRotationOn(){
        if (GetComponent<ObjectSelection>().isSelectedObject == true){
                toggleRotation = true;
        } 
    }

    public void RotateAroundUpAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, mainCamera.transform.up) * currentObjRotation;
    }

    public void RotateAroundDownAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, -mainCamera.transform.up) * currentObjRotation;
    }

    public void RotateAroundLeftAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, mainCamera.transform.forward) * currentObjRotation;

        
    }

    public void RotateAroundRightAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, -mainCamera.transform.forward) * currentObjRotation;
            
    }

    public void RotateAroundForwardAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, mainCamera.transform.right) * currentObjRotation;
    }
    public void RotateAroundBackwardAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, -mainCamera.transform.right) * currentObjRotation;
    }
}
