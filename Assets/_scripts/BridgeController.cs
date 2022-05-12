using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour {

    public int[] padsOpt = {0, 1, 0, 0, 1, 1};
    
    void Start() {
        truePads();
    }

    void truePads(){
        int i = 0;
        foreach(RowController row in GetComponentsInChildren<RowController>()) {
            row.setTruePad(padsOpt[i]);
            i++;
        }
    }
}
