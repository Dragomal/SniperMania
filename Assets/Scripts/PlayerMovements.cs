using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    private Vector2 moveAxis;
    private Vector2 lookAxis;
    private float xRotation;
    public CharacterController characterController;
    public float multiplierSpeed = 10f;
    public float lookSpeed = 1;
    public Transform cameratransform;
    public float minXRotation = -60;
    public float maxXRotation = 60;
    public void OnMove(InputAction.CallbackContext callback){
        moveAxis = callback.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext callback){
        lookAxis = callback.ReadValue<Vector2>();
    }
    
    private void Update(){
        // Move
        Vector3 direction = new Vector3(moveAxis.x, 0f,  moveAxis.y);
        direction = transform.TransformDirection(direction);
        direction *= multiplierSpeed;
        characterController.Move(direction * Time.deltaTime);
        
        // Look
        // if(Application.isEditor && !Input.GetKey(KeyCode.LeftAlt)) return;

        xRotation += lookAxis.y * lookSpeed;
        transform.Rotate(0f, lookAxis.x * lookSpeed, 0f);
        xRotation = Mathf.Clamp(xRotation, minXRotation, maxXRotation);
        cameratransform.localEulerAngles = new Vector3(xRotation, 0f, 0f);
    }
}
