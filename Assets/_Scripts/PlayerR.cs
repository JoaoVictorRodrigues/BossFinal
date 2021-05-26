using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerR : MonoBehaviour
{
    
    private Vector2 pos;
    public float IncX;
    public float maxWidth;
    public float minWidth;
    public float speed;

    private GameManager gm;

    
    void Start(){
        gm = GameManager.GetInstance();
    }

    void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;
        transform.position = Vector2.MoveTowards(transform.position, pos, speed*Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < maxWidth){
            pos = new Vector2(transform.position.x + IncX, transform.position.y);
            transform.position = pos;
        }else if(Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minWidth){
            pos = new Vector2(transform.position.x - IncX, transform.position.y);
            transform.position = pos;
        }
    }

    public void TakeDamage(){
        gm.vidas--;
        Debug.Log(gm.vidas);
        if (gm.vidas <= 0){
            Die();  
        } 
    }

    public void Die(){
        gm.ChangeState(GameManager.GameState.ENDGAME);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("ObstacleR")){
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
    
}
