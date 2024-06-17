using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;
    [SerializeField] GameManager gameManager;
    public int combo = 0, score = 0, multiplier = 1;

    public int Score{
        get{return score;}
        set{
            score = value;
            if(Multiplier < 8) Multiplier *= 2;
            Combo ++;
        }
    }

    public int Multiplier{
        get{return multiplier;}
        set{
            multiplier = value;
        }
    }

    public int Combo{
        get{return combo;}
        set{
            combo = value;
            CanvaManager.instance.UpdateCanvaScore(Score, Combo, Multiplier);
        }
    }

    void Awake(){
        instance = this;
    }

    public void AddPoints(string bodyPart){
        switch (bodyPart){
            case "Head":
                Score += 1000 * Multiplier;
                break;
            case "Chest":
                Score += 700 * Multiplier;
                break;
            case "Legs":
                Score += 500 * Multiplier;
                break;
        }
        GameManager.instance.CreateMob();
    }

    public void MissShot(){
        if(Multiplier > 1) Multiplier /= 2;
        Combo = 0;
    }
}
