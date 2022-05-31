using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PadController : MonoBehaviour {

    private bool fallDownFlag = false;
    private GameObject pS;
    public Vector3 originalPos;
    private TeleportPoint tp;
    public bool isFirstRow = false;
    private Light myLight;

    void Start() {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        pS = GameObject.FindGameObjectWithTag("Player");
        tp = GetComponentInChildren(typeof(TeleportPoint), true) as TeleportPoint;
        myLight = GetComponentInChildren(typeof(Light), true) as Light;
        if (!isFirstRow) {
            tp.locked = true;
            myLight.enabled = false;
        } else {
            tp.locked = false;
            myLight.color = Color.white;
        }
    }

    void Update() {
        if(!pS.GetComponent<PlayerController>().isAlive()) {
            this.transform.position = originalPos;
            myLight.enabled = false;
            if (!isFirstRow) {
                tp.locked = true;
                myLight.enabled = false;
                myLight.color = Color.white;
            } else {
                tp.locked = false;
                myLight.color = Color.white;
                myLight.enabled = true;
            }
        } 
            
    }

    void LateUpdate() {
        gravityOnpad();
    }

    public void setIsNextRow() {
        tp.locked = false;
        myLight.color = Color.white;
        myLight.enabled = true;
    }

    public void turnOnSignLight(Color c) {
        myLight.color = c;
    }

    public void turnOffSignLight() {
        myLight.enabled = false;
    }
    
    public void gravityOnpad(){
        if (this.fallDownFlag){
            this.transform.position = this.transform.position - new Vector3(0f, 0.1f, 0f);
        }
    }

    public void fallDown() {
        this.fallDownFlag = true;
    }

    public bool getIsFalling() {
        if(!pS.GetComponent<PlayerController>().isAlive()) {
            this.fallDownFlag = false;
        }
        return this.fallDownFlag;
    }
    
}
