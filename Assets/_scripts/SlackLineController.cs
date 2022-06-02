using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlackLineController : MonoBehaviour {
    private GameObject player;
    private Rigidbody playerRb;
    private GameObject ObjA;
    private GameObject ObjB;
    private bool startedSlackFlag = false;
    private GameObject TpObj;


    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody>();
        ObjA = GameObject.FindGameObjectWithTag("Obj_A");
        ObjB = GameObject.FindGameObjectWithTag("Obj_B");
        TpObj = GameObject.FindGameObjectWithTag("TpObj");
    }

    void Update() {
        if (!startedSlackFlag) {
            if (player.transform.position.x > ObjA.transform.position.x && player.transform.position.x < ObjB.transform.position.x) {
                startedSlackFlag = true;
                TpObj.SetActive(false);
                player.GetComponent<CharacterController>().enabled = true;
                player.GetComponent<TrackPadWalk>().enabled = true;
            }
        } else {
            if (player.transform.position.z > 0.72f || player.transform.position.z < -0.72f) {
                Debug.Log("Desligando trackpad");
                playerRb.constraints &= ~RigidbodyConstraints.FreezePositionY;
                player.GetComponent<CharacterController>().enabled = false;
                player.GetComponent<TrackPadWalk>().enabled = false;
                startedSlackFlag = false;
            }

            if (player.transform.position.x <= ObjA.transform.position.x - 0.5f) {
                // Volta pro tp
                playerRb.constraints &= ~RigidbodyConstraints.FreezePositionY;
                player.GetComponent<CharacterController>().enabled = false;
                player.GetComponent<TrackPadWalk>().enabled = false;
                startedSlackFlag = false;
            }

            if (player.transform.position.x >= ObjB.transform.position.x) {
                // Aumenta velocidade do player
                // player.GetComponent<TrackPadWalk>().setNewPlayerSpeed(5f);
                startedSlackFlag = false;
            }
        }
    }

    public void resetStartedSlackFlag() {
        this.startedSlackFlag = false;
    }
}
