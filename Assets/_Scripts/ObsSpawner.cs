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

    private int[] points;
    private int i;

    void Start()
    {
        gm = GameManager.GetInstance();
        i = 0;
        points = new int[5]{1,1,1,1,1}; 
    }

    void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;

        if (i>=points.Length){
            i = 0;
        }
        
        // int random = Random.Range(0,obstaclePositions.Length);
        if (timeBtwSpawn <= 0 ){
            
            Instantiate(obstaclePositions[points[i]],transform.position,Quaternion.identity);
            
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime){
                startTimeBtwSpawn -= decreaseTime;
            }
        }else{
            timeBtwSpawn -= Time.deltaTime;
        }
        i++;
    }
}
