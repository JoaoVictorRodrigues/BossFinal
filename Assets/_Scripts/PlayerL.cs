using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerL : MonoBehaviour{
    private Vector2 pos;
    public float IncX;
    public float maxWidth;
    public float minWidth;
    public float speed;

    private GameManager gm;

    public AudioClip transitionSFX;
    
    void Start(){
        gm = GameManager.GetInstance();
    }

    void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;
        
        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME){
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
        transform.position = Vector2.MoveTowards(transform.position, pos, speed*Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.D) && transform.position.x < maxWidth){
            AudioManager.PlaySFX(transitionSFX);
            pos = new Vector2(transform.position.x + IncX, transform.position.y);
            transform.position = pos;
        }else if(Input.GetKeyDown(KeyCode.A) && transform.position.x > minWidth){
            AudioManager.PlaySFX(transitionSFX);
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
        if (collision.CompareTag("Obstacle")){
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
    
}
