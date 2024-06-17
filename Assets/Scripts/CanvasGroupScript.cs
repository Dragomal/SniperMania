using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CanvasGroupScript : MonoBehaviour
{
    public static CanvasGroupScript instance;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Image hitmarkerSprite;
    void Awake()
    {
        instance = this;
    }
    public void HitMarkerBody(){
        hitmarkerSprite.color = Color.white;
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0, 1);
    }
    public void HitMarkerHead(){
        hitmarkerSprite.color = Color.red;
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0, 1);
    }
}
