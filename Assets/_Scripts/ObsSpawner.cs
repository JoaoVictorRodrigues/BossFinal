using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawner : MonoBehaviour
{
    private GameManager gm;
    public GameObject[] obstaclePositions;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;
    public float lifetime;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;
        
        int random = Random.Range(0,obstaclePositions.Length);
        if (timeBtwSpawn <= 0 ){
            
            Instantiate(obstaclePositions[random],transform.position,Quaternion.identity);
            
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime){
                startTimeBtwSpawn -= decreaseTime;
            }
        }else{
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
