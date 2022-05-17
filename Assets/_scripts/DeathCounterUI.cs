using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounterUI : MonoBehaviour {

    private PlayerController player;
    private int deaths;
    private Text deathsText;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        deathsText = gameObject.GetComponent<Text>();
    }

    void Update() {
        if (deaths != player.numberOfDeaths()) {
            deaths = player.numberOfDeaths();
            deathsText.text = $"Deaths: {deaths}";
        }
    }
}
