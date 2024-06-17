using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedback : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] AudioClip snipershotAudio, hitmarkerHead, hitmarkerBody;
    [SerializeField] ParticleSystem fireShot, smokeShot, smokeCanonShot;
    public void Shot(){
        CameraShake mainCameraShake = mainCamera.GetComponent<CameraShake>();
        StartCoroutine(mainCameraShake.Shake(0.15f, 0.1f));
        AudioManager.Instance.PlaySFX(snipershotAudio);
        fireShot.Play();
        smokeShot.Play();
        smokeCanonShot.Play();
    }
    public void DummyHit(string dummyPart){
        if(dummyPart == "Head"){
            CanvasGroupScript.instance.HitMarkerHead();
            AudioManager.Instance.PlaySFX(hitmarkerHead);
        }
        else{
            CanvasGroupScript.instance.HitMarkerBody();
            AudioManager.Instance.PlaySFX(hitmarkerBody);
        }
    }
}
