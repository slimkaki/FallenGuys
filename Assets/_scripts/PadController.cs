using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour {

    private bool fallDownFlag = false;

    void LateUpdate() {
        if (fallDownFlag)
            this.transform.position = this.transform.position - new Vector3(0f, 0.1f, 0f);
    }

    public void fallDown() {
        fallDownFlag = true;
    }

    public bool getIsFalling() {
        return this.fallDownFlag;
    }

}
