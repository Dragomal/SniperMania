using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHitbox : MonoBehaviour
{
    [SerializeField] PlayerFeedback playerFeedback;
    [SerializeField] GameObject dummy;
    public void GetHit(){
        PlayerScore.instance.AddPoints(gameObject.tag);
        playerFeedback.DummyHit(gameObject.tag);
        DestroyImmediate(dummy);
    }
}
