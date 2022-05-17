using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool alive;
    public int deaths;
    private Rigidbody rb;
    
    void Start() {
        alive = true;
        deaths = 0;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if(this.transform.position.y < -7f && alive){
            alive = false;
            Debug.Log(alive);
            
            deaths++;
            StartCoroutine("Reset");
        }
    }

    public bool isAlive() {
        return this.alive;
    }

    public int numberOfDeaths() {
        return this.deaths;
    }

    void respawn(){
        Debug.Log(alive);
        this.transform.position = new Vector3(0, 1.7f, 0);
        rb.velocity = new Vector3(0f, 0f, 0f);
        alive = true;
    }

    IEnumerator Reset() {
        yield return new WaitForSeconds(0.1f);
        respawn();
    }
}
