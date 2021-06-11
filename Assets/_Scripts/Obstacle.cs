using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    public float screenEnd;

    private GameManager gm;

    public GameObject effect;

    public AudioClip explosionSFX;

    // Start is called before the first frame update
    void Start() {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update() {
        if (gm.gameState != GameManager.GameState.GAME) return;
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < screenEnd)
        {
            Destroy (gameObject);
            gm.pontos += 10;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            AudioManager.PlaySFX(explosionSFX);
            Instantiate(effect,transform.position,Quaternion.identity);
        }
    }
}
