using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerL : MonoBehaviour
{
    private Vector2 pos;
    public float IncX;
    public float maxWidth;
    public float minWidth;
    public float speed;
    
    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos, speed*Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.D) && transform.position.x < maxWidth){
            pos = new Vector2(transform.position.x + IncX, transform.position.y);
            transform.position = pos;
        }else if(Input.GetKeyDown(KeyCode.A) && transform.position.x > minWidth){
            pos = new Vector2(transform.position.x - IncX, transform.position.y);
            transform.position = pos;
        }
    }
    
}
