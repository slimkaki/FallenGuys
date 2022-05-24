using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlackLineController : MonoBehaviour {
    private GameObject player;
    private Rigidbody playerRb;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<RigidBody>();
    }

    void Update() {
        if ()
    }
}
