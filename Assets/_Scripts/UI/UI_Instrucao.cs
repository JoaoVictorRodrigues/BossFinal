using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Instrucao : MonoBehaviour
{
    GameManager gm;
     private void OnEnable(){
        gm = GameManager.GetInstance();
    }


    public void Comecar(){
        gm.ChangeState(GameManager.GameState.GAME);
        // pontos.SetActive(true);
        // vidas.SetActive(true);
    }
    void Update(){
        
        if(Input.GetKeyDown(KeyCode.Space) && gm.gameState == GameManager.GameState.TUTORIAL){
            gm.ChangeState(GameManager.GameState.GAME);
        }
    }
}
