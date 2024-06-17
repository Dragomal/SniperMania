using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Transform> gameMobSpawns = new List<Transform>();
    [SerializeField] GameObject mobPrefab;
    public static GameManager instance;
    void Start(){
        CreateMob();
        instance = this;
    }
    public void CreateMob(){
        int randomIndex = Random.Range(0, gameMobSpawns.Count);
        float xPos = gameMobSpawns[randomIndex].position.x;
        float yPos = gameMobSpawns[randomIndex].position.y - 0.5f;
        float zPos = gameMobSpawns[randomIndex].position.z;
        if(gameMobSpawns[randomIndex].name == "SpawnMobSurface"){
            float xScale = gameMobSpawns[randomIndex].localScale.x / 2;
            float zScale = gameMobSpawns[randomIndex].localScale.z / 2;
            xPos += Random.Range(xScale*-1, xScale);
            zPos += Random.Range(zScale*-1, zScale);
        }
        Instantiate(mobPrefab, new Vector3(xPos, yPos, zPos), Quaternion.Euler(0, 180, 0));
    }
}
