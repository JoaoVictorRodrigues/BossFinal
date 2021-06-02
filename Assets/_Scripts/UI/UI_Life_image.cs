using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Life_image : MonoBehaviour{
    private GameManager gm;
    public GameObject[] lifes;
    void Start(){
        gm = GameManager.GetInstance();
        // lifes[0].gameObject.SetActive(true);
        // lifes[1].gameObject.SetActive(true);
        // lifes[2].gameObject.SetActive(true);
    }

    void Update() {
        if(gm.vidas < 1){
            lifes[0].gameObject.SetActive(false);
            lifes[1].gameObject.SetActive(false);
            lifes[2].gameObject.SetActive(false);
        } else if(gm.vidas < 2){
            lifes[0].gameObject.SetActive(true);
            lifes[1].gameObject.SetActive(false);
            lifes[2].gameObject.SetActive(false);
        } else if(gm.vidas < 3){
            lifes[0].gameObject.SetActive(true);
            lifes[1].gameObject.SetActive(true);
            lifes[2].gameObject.SetActive(false);
        } else if(gm.vidas >= 3) {
            lifes[0].gameObject.SetActive(true);
            lifes[1].gameObject.SetActive(true);
            lifes[2].gameObject.SetActive(true);
        }
    }

}
