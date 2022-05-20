using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour {

    private GameObject player;
    private GameObject leftPad;
    private GameObject rightPad;
    public PlayerController pS;
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
            if (Mathf.Abs(leftPad.transform.position.z - player.transform.position.z) > Mathf.Abs(rightPad.transform.position.z - player.transform.position.z)) {
                // Player na direita
                Debug.Log($"playerAlive? -> {pS.alive}");
                if (truePad == 0 && !rightPad.GetComponent<PadController>().getIsFalling() && pS.alive) {
                    rightPad.GetComponent<PadController>().fallDown();
                    player.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
                    rightPad.GetComponent<PadController>().turnOnSignLight(Color.red);
                }

                if (truePad == 1) {
                    leftPad.GetComponent<PadController>().turnOnSignLight(Color.red);
                    rightPad.GetComponent<PadController>().turnOnSignLight(Color.green);
                }
            } else {
                // Player na esquerda
                if (truePad == 1 && !leftPad.GetComponent<PadController>().getIsFalling() && pS.alive) {
                    leftPad.GetComponent<PadController>().fallDown();
                    player.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
                    leftPad.GetComponent<PadController>().turnOnSignLight(Color.red);
                }

                if (truePad == 0) {
                    rightPad.GetComponent<PadController>().turnOnSignLight(Color.red);
                    leftPad.GetComponent<PadController>().turnOnSignLight(Color.green);
                }
            }
            
        } else if (player.transform.position.x - this.transform.position.x < 0f && player.transform.position.x - this.transform.position.x >= -4f) {
            // Precisa de bugfix, tem que resetar os tps locked quando o player da respawn, e checar pq a mao atrapalha tanto o collider
            rightPad.GetComponent<PadController>().setIsNextRow();
            leftPad.GetComponent<PadController>().setIsNextRow();
        }
    }

    public void setTruePad(int tp) {
        // 0 when right, 1 when left
        this.truePad = tp;
    }
}
