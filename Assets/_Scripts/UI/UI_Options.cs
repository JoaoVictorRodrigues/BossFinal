using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Options : MonoBehaviour{
    GameManager gm;

    private void OnEnable(){
        gm = GameManager.GetInstance();
    }

    public void Voltar(){
        gm.ChangeState(GameManager.GameState.MENU);
    }

}
