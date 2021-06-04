using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpawner : MonoBehaviour{
    private GameManager gm;
    public GameObject[] PUPositions;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;

    void Start() {
        gm = GameManager.GetInstance();

    }

    void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;

        int random = Random.Range(0,PUPositions.Length);
        if (timeBtwSpawn <= 0 ){
            
            Instantiate(PUPositions[random],transform.position,Quaternion.identity);
            
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime){
                startTimeBtwSpawn -= decreaseTime;
            }
        }else{
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}

