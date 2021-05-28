using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    GameManager gm;
    public float speed;
    public float startY;
    public float endY;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;
        transform.Translate(Vector2.down * speed* Time.deltaTime);

        if (transform.position.y <= endY){
            Vector2 pos =  new Vector2(transform.position.x, startY);
            transform.position = pos;
        }
    }
}