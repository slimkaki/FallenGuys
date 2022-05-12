using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour {

    private bool fallDownFlag = false;
    public player_controller pS;
    public Vector3 originalPos;

    void Start(){
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    void Update() {
        Debug.Log(fallDownFlag);
        resetPosition();
    }

    void LateUpdate() {
        gravityOnpad();
    }
    
    
    public void gravityOnpad(){
        if (this.fallDownFlag){
            Debug.Log("falling pad");
            this.transform.position = this.transform.position - new Vector3(0f, 0.1f, 0f);
        }
    }

    public void fallDown() {
        this.fallDownFlag = true;
    }

    public bool getIsFalling() {
        Debug.Log("sendo chamado na func externa");
        if(!pS.alive){
            this.fallDownFlag = false;
        }
        return this.fallDownFlag;
    }
    public void resetPosition(){
        if(!pS.alive){
            Debug.Log("reseting pad");
            // this.fallDownFlag = false;
            this.transform.position = originalPos;
        }
    }
}
