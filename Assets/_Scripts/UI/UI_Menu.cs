using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : MonoBehaviour{

    GameManager gm;
    public GameObject pontos;
    public GameObject vidas;

    private void OnEnable(){
        gm = GameManager.GetInstance();
    }

    public void Comecar(){
        gm.ChangeState(GameManager.GameState.TUTORIAL);
        // pontos.SetActive(true);
        // vidas.SetActive(true);
    }

    public void Options(){
        gm.ChangeState(GameManager.GameState.OPTIONS);
    }

}
