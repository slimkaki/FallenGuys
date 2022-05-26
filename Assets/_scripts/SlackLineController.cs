using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlackLineController : MonoBehaviour {
    private GameObject player;
    private Rigidbody playerRb;
    private GameObject ObjA;
    private GameObject ObjB;
    private bool startedSlackFlag = false;


    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody>();
        ObjA = GameObject.FindGameObjectWithTag("Obj_A");
        ObjB = GameObject.FindGameObjectWithTag("Obj_B");
    }

    void Update() {
        if (!startedSlackFlag) {
            if (player.transform.position.x > ObjA.transform.position.x && player.transform.position.x < ObjB.transform.position.x && Mathf.Abs(player.transform.position.z - ObjA.transform.position.z) <= 1f) {
                startedSlackFlag = true;
                player.GetComponent<CharacterController>().enabled = true;
                player.GetComponent<TrackPadWalk>().enabled = true;
                playerRb.constraints = RigidbodyConstraints.None;
            } else {
                startedSlackFlag = false;
            }
        } else {
            if (player.transform.position.x <= ObjA.transform.position.x && player.transform.position.x >= ObjB.transform.position.x && Mathf.Abs(player.transform.position.z - ObjA.transform.position.z) > 1f) {
                player.GetComponent<CharacterController>().enabled = false;
                player.GetComponent<TrackPadWalk>().enabled = false;
                playerRb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
            }
            if (player.transform.position.x > ObjA.transform.position.x && player.transform.position.x < ObjB.transform.position.x && Mathf.Abs(player.transform.position.z - ObjA.transform.position.z) > 1f) {
                player.GetComponent<CharacterController>().enabled = false;
                player.GetComponent<TrackPadWalk>().enabled = false;
                player.transform.position = player.transform.position - new Vector3(0f, 0.1f, 0f);
            }
        }
    }
}
