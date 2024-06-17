using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Tag head, chest, legs, wall;
    [SerializeField] float bulletradius;
    private Vector3 lastPos;

    void Awake(){
        StartCoroutine(BulletLife());
        lastPos = transform.position;
    }

    IEnumerator BulletLife(){
        yield return new WaitForSeconds(1f);
        PlayerScore.instance.MissShot();
        Destroy(this.gameObject);
    }

    void OnHit(Transform hitTarget){
        // Debug.Log("OnHit !" + hitTarget.name);
        DummyHitbox dummyHitbox = hitTarget.gameObject.GetComponent<DummyHitbox>();

        if(hitTarget.CompareTag(head.name)){
            dummyHitbox.GetHit();
            DoDestroy();
        }
        else if(hitTarget.CompareTag(chest.name)){
            dummyHitbox.GetHit();
            DoDestroy();
        }
        else if(hitTarget.CompareTag(legs.name)){
            dummyHitbox.GetHit();
            DoDestroy();
        }
        else if(hitTarget.CompareTag(wall.name)){
            PlayerScore.instance.MissShot();
            DoDestroy();
        }
    }

    void DoDestroy(){
        StopAllCoroutines();
        Destroy(this.gameObject);
        enabled = false;
    }

    void FixedUpdate(){
        if(!enabled) return;
        float distance = Vector3.Distance(lastPos, transform.position);
        if(distance < Physics.defaultContactOffset) return;

        bool isRay = Physics.SphereCast(transform.position , bulletradius, transform.position - lastPos,
        out RaycastHit rayHit, distance, -1, QueryTriggerInteraction.Collide);

        Debug.DrawLine(lastPos, transform.position, Color.red, 2f);
        if(isRay){
            OnHit(rayHit.transform);
        }

        lastPos = transform.position;
    }
}
