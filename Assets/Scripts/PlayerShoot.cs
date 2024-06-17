using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletInstantiator;
    [SerializeField] float shootSpeed;
    [SerializeField] PlayerFeedback playerFeedback;

    public void OnShoot(InputAction.CallbackContext callback){
        if(callback.performed){
            GameObject newBullet = Instantiate(bulletPrefab, bulletInstantiator.position, bulletInstantiator.rotation);
            Rigidbody newBulletRigidbody = newBullet.GetComponent<Rigidbody>();
            newBulletRigidbody.AddForce(bulletInstantiator.forward * shootSpeed, ForceMode.Impulse);
        }
        playerFeedback.Shot();
    }
}
