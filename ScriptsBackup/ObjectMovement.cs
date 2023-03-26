using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectMovement : MonoBehaviour
{
    [System.NonSerialized]
    public GameObject mainObject;
    Camera mainCamera;
    Vector3 currentObjPosition;
    float verticalObjSpeed = 4f;
    float horizontalObjSpeed = 5f;


    private void Start() {
    mainCamera = Camera.main;
    }

    public void MoveUp (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObject.transform.position;
        mainObject.transform.position +=  mainCamera.transform.up * verticalObjSpeed * Time.deltaTime;
    }

    public void MoveDown (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObject.transform.position;
        mainObject.transform.position -=  mainCamera.transform.up * verticalObjSpeed * Time.deltaTime;
    }

    public void MoveLeft (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObject.transform.position;
        mainObject.transform.position -=  mainCamera.transform.right * horizontalObjSpeed * Time.deltaTime;
    }

    public void MoveRight (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObject.transform.position;
         mainObject.transform.position +=  mainCamera.transform.right * horizontalObjSpeed * Time.deltaTime;
    }

    public void MoveForward (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObject.transform.position;
        mainObject.transform.position +=  mainCamera.transform.forward * horizontalObjSpeed * Time.deltaTime;
    }
    public void MoveBackward (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObject.transform.position;
        mainObject.transform.position -=  mainCamera.transform.forward * horizontalObjSpeed * Time.deltaTime;
    }
}
