using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        currentObjPosition = mainObject.transform.position;
        mainObject.transform.position +=  mainCamera.transform.up * verticalObjSpeed * Time.deltaTime;
    }

    public void MoveDown (){
        currentObjPosition = mainObject.transform.position;
        mainObject.transform.position -=  mainCamera.transform.up * verticalObjSpeed * Time.deltaTime;
    }

    public void MoveLeft (){
        currentObjPosition = mainObject.transform.position;
        mainObject.transform.position -=  mainCamera.transform.right * horizontalObjSpeed * Time.deltaTime;
    }

    public void MoveRight (){
        currentObjPosition = mainObject.transform.position;
         mainObject.transform.position +=  mainCamera.transform.right * horizontalObjSpeed * Time.deltaTime;
    }

    public void MoveForward (){
        currentObjPosition = mainObject.transform.position;
        mainObject.transform.position +=  mainCamera.transform.forward * horizontalObjSpeed * Time.deltaTime;
    }
    public void MoveBackward (){
        currentObjPosition = mainObject.transform.position;
        mainObject.transform.position -=  mainCamera.transform.forward * horizontalObjSpeed * Time.deltaTime;
    }
}
