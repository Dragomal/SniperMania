using UnityEngine;
using UnityEngine.InputSystem;

public class OnClick : MonoBehaviour
{
    // Définition des 2 canvas qui permettent de viser 
    public GameObject x5Scope;
    public GameObject x10Scope;
    public PlayerMovements player;

    // Désactive le curseur
    void Start(){
        Cursor.visible = false;
    }
    
    public void Onx5Scope(InputAction.CallbackContext callback){
        player.lookSpeed = 0.5f;
        x5Scope.SetActive(true);
        x10Scope.SetActive(false);
        if(callback.canceled){
            x5Scope.SetActive(false);
            x10Scope.SetActive(false);
            player.lookSpeed = 1f;
        }
    }

    public void Onx10Scope(InputAction.CallbackContext callback){
        player.lookSpeed = 0.1f;
        x5Scope.SetActive(false);
        x10Scope.SetActive(true);
        if(callback.canceled){
            x10Scope.SetActive(false);
            player.lookSpeed = 1f;
        }
    }
}
