using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour {

    private GameObject player;
    private GameObject leftPad;
    private GameObject rightPad;
    public player_controller pS;
    public int truePad;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        foreach(Transform pad in GetComponentsInChildren<Transform>()) {
            if (pad.gameObject.name == "right") {
                rightPad = pad.gameObject;
            } else if (pad.gameObject.name == "left") {
                leftPad = pad.gameObject;
            }
        }
    }

    void Update() {
        if (Mathf.Abs(player.transform.position.x - this.transform.position.x) <= 1f) {
            // Debug.Log($"truePad = {truePad} - {this.gameObject.name}");
            if (Mathf.Abs(leftPad.transform.position.z - player.transform.position.z) > Mathf.Abs(rightPad.transform.position.z - player.transform.position.z)) {
                // Player na direita
                Debug.Log($"playerAlive? -> {pS.alive}");
                if (truePad == 0 && !rightPad.GetComponent<PadController>().getIsFalling() && pS.alive)
                    rightPad.GetComponent<PadController>().fallDown();
            } else {
                // Player na esquerda
                // Debug.Log($"leftPad -> {leftPad}");
                if (truePad == 1 && !leftPad.GetComponent<PadController>().getIsFalling() && pS.alive)
                    leftPad.GetComponent<PadController>().fallDown();
            }
        }
    }

    public void setTruePad(int tp) {
        // 0 when right, 1 when left
        this.truePad = tp;
    }
}
