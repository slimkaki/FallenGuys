using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public bool alive;
    public int deaths;
    
    void Start()
    {
        alive = true;
        deaths = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -7f){
            alive = false;
            Debug.Log("you died");
            
            deaths ++;
            respawn();
        }
    }
    void respawn(){
        alive = true;

        Debug.Log("you revived");
        this.transform.position = new Vector3(0, 1.7f, 0);
        
    }
}
