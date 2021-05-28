using UnityEngine;
using UnityEngine.UI;

public class UI_Pontos : MonoBehaviour{
    Text textComp;
    GameManager gm;
    
    void Start(){
        
        gm = GameManager.GetInstance();
        gameObject.SetActive(false);
        textComp = GetComponent<Text>();
    }
   
    void Update(){

        textComp.text = $"Pontos: {gm.pontos}";
    }
}