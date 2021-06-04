using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour{
    public float speed;
    public float screenEnd;

    private GameManager gm;

    public AudioClip powerupSFX;

    // Start is called before the first frame update
    void Start() {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update() {
        if (gm.gameState != GameManager.GameState.GAME) return;
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < screenEnd){
            Destroy (gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            AudioManager.PlaySFX(powerupSFX);
        }
    }
}