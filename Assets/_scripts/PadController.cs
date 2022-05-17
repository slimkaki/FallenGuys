using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PadController : MonoBehaviour {

    private bool fallDownFlag = false;
    public GameObject pS;
    public Vector3 originalPos;
    private TeleportPoint tp;
    private bool isNextRow = false;
    public bool isFirstRow = false;

    void Start() {
        isNextRow = false;
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        pS = GameObject.FindGameObjectWithTag("Player");
        tp = GetComponentInChildren(typeof(TeleportPoint), true) as TeleportPoint;
        if (!isFirstRow)
            tp.locked = true;
    }

    void Update() {
        // Debug.Log($"isAlive Update padcontroller {pS.GetComponent<PlayerController>().isAlive()}");
        if(!pS.GetComponent<PlayerController>().isAlive()) {
            // Debug.Log("reseting pad");
            this.transform.position = originalPos;
        } 

        if (isNextRow)
            tp.locked = false;
    }

    void LateUpdate() {
        gravityOnpad();
    }

    public void setIsNextRow() {
        this.isNextRow = true;
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
        Debug.Log("getIsFaling");
        if(!pS.GetComponent<PlayerController>().isAlive()){
            this.fallDownFlag = false;
        }
        return this.fallDownFlag;
    }
    
}
