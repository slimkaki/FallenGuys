using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool alive;
    public int deaths;
    private Rigidbody rb;
    private GameObject TpObj;
    public GameObject UIEND;
    private SlackLineController slackLine;
    // Grabbable Objects
    private GameObject starObj;
    private Vector3 starPos;
    private Quaternion starRot;


    private GameObject rocketObj;
    private Vector3 rocketPos;
    private Quaternion rocketRot;

    private GameObject coinObj;
    private Vector3 coinPos;
    private Quaternion coinRot;
    
    //end game variables

    void Start() {
        alive = true;
        deaths = 0;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
        TpObj = GameObject.FindGameObjectWithTag("TpObj");
        slackLine = GameObject.FindGameObjectWithTag("slackline").GetComponent<SlackLineController>();
        
        starObj = GameObject.FindGameObjectWithTag("star");
        starPos = starObj.transform.position;
        starRot = starObj.transform.rotation;

        rocketObj = GameObject.FindGameObjectWithTag("rocket");
        rocketPos = rocketObj.transform.position;
        rocketRot = rocketObj.transform.rotation;

        coinObj = GameObject.FindGameObjectWithTag("coin");
        coinPos = coinObj.transform.position;
        coinRot = coinObj.transform.rotation;

        
    }

    // Update is called once per frame
    void Update() {
        if(this.transform.position.y < -7f && alive){
            alive = false;
            deaths++;
            StartCoroutine("Reset");
        }
        if(rocketObj.GetComponent<objBehav>().getTouched() && starObj.GetComponent<objBehav>().getTouched() && coinObj.GetComponent<objBehav>().getTouched()){
            showUI();
        }
    }

    private void showUI() {
        UIEND.SetActive(true);
    }

    
    public void setEndGame(){
        deaths = 0;
        respawn();
        UIEND.SetActive(false);
    }

    public bool isAlive() {
        return this.alive;
    }

    public int numberOfDeaths() {
        return this.deaths;
    }

    void respawn(){
        this.transform.position = new Vector3(0, 0.7f, 0);
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
        this.GetComponent<CharacterController>().enabled = false;
        this.GetComponent<TrackPadWalk>().enabled = false;
        TpObj.SetActive(true);
        slackLine.resetStartedSlackFlag();
        // Restaurando objetos
        starObj.transform.position = starPos;
        starObj.transform.rotation = starRot;
        starObj.GetComponent<objBehav>().setTouchedToFalse();

        rocketObj.transform.position = rocketPos;
        rocketObj.transform.rotation = rocketRot;
        rocketObj.GetComponent<objBehav>().setTouchedToFalse();

        coinObj.transform.position = coinPos;
        coinObj.transform.rotation = coinRot;
        coinObj.GetComponent<objBehav>().setTouchedToFalse();

        alive = true;
    }

    IEnumerator Reset() {
        yield return new WaitForSeconds(0.5f);
        respawn();
    }
}
