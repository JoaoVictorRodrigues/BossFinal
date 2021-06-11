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

    public AudioClip transitionSFX;
    public AudioClip gameoverSFX;

    public GameObject shield;

    
    void Start(){
        gm = GameManager.GetInstance();
        shield.SetActive(false);
    }

    void Update(){
        if (gm.gameState != GameManager.GameState.GAME) return;
        transform.position = Vector2.MoveTowards(transform.position, pos, speed*Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < maxWidth){
            AudioManager.PlaySFX(transitionSFX);
            pos = new Vector2(transform.position.x + IncX, transform.position.y);
            transform.position = pos;
        }else if(Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minWidth){
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
        AudioManager.PlaySFX(gameoverSFX);
        gm.ChangeState(GameManager.GameState.ENDGAME);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("ObstacleL")){
            if(shield.activeInHierarchy){
                Debug.Log("SIM, ESTÁ ATIVO NA CARALHA DA HIERAQUIA");
                shield.SetActive(false);
            } else {
                Debug.Log("SE FODEO E TOMOU DANO");
                TakeDamage();
            }
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("PowerUp")){
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("PointsUp")){
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("DefenceUp")){
            Destroy(collision.gameObject);
            shield.SetActive(true);
            Debug.Log("SIM, EU ATIVEI O SHIELD CARALHO");
        }
    }
    
}
