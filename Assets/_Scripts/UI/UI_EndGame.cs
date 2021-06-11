  
using UnityEngine;
using UnityEngine.UI;
public class UI_EndGame : MonoBehaviour{
public Text message;
public Text pontos;
GameManager gm;
private void OnEnable(){
    gm = GameManager.GetInstance();

    if(gm.vidas > 0){
        message.text = "Você Ganhou!!!";
        pontos.text = $"Pontos: {gm.pontos}";
    } else {
        message.text = "Você Perdeu!!";
        pontos.text = $"Pontos: {gm.pontos}";
    }

}

    public void Voltar(){
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
