using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour {

    private GameObject player;
    private GameObject leftPad;
    private GameObject rightPad;
    public int truePad;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        foreach(Transform pad in GetComponentsInChildren<Transform>()) {
            if (pad.gameObject.name == "right") {
                rightPad = pad.gameObject;
            } else {
                leftPad = pad.gameObject;
            }
        }
    }

    void Update() {
        if (Mathf.Abs(player.transform.position.x - this.transform.position.x) <= 1f) {
            Debug.Log($"truePad = {truePad} - {this.gameObject.name}");
            if (Mathf.Abs(leftPad.transform.position.z - player.transform.position.z) > Mathf.Abs(rightPad.transform.position.z - player.transform.position.z)) {
                Debug.Log("to na direita");
                
            } else {
                Debug.Log("To na esquerda");
            }
        }
    }

    public void setTruePad(int tp) {
        this.truePad = tp;
    }
}
