using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPosition : MonoBehaviour{

    public GameObject PowerUp;
    void Start(){
        Instantiate(PowerUp,transform.position,Quaternion.identity); 
    }

}

