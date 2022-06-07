using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class objBehav : MonoBehaviour
{
    
    private Rigidbody body;
    private GameObject snapTo;
    public float snapTime = 3;
    private float dropTimer;
    private Interactable interactable;
    private bool touched = false;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        body = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag  == this.gameObject.tag + "Shadow") 
        {
            
            touched = true;
            snapTo = col.gameObject;
            
            //thePlayer.transform.position = new Vector3(0, 5, 0);
        }
    }

    protected void HandAttachedUpdate(Hand hand)
    {
        // Se tocar no colisor, soltar da mão
        if (touched)
            hand.DetachObject(gameObject, false);
    }

    private void FixedUpdate()
    {
        bool used = false;
        if (interactable != null)
            used = interactable.attachedToHand;

        if (used)
        {
            body.isKinematic = false;
            dropTimer = -1;
        }
        else    
        {
            if (touched)
            {
                dropTimer += Time.deltaTime / (snapTime / 2);
                body.isKinematic = dropTimer > 1;

                if (dropTimer > 1)
                {
                    transform.position = snapTo.transform.position;
                    transform.rotation = snapTo.transform.rotation;
                    // snapTo.GetComponent<Collider>().enabled = false; // achei melhor desligar o collider
                }
                else
                {
                    float t = Mathf.Pow(35, dropTimer);

                    body.velocity = Vector3.Lerp(body.velocity, Vector3.zero, Time.fixedDeltaTime * 4);
                    if (body.useGravity)
                        body.AddForce(-Physics.gravity);

                    transform.position = Vector3.Lerp(transform.position, snapTo.transform.position, Time.fixedDeltaTime * t * 3);
                    transform.rotation = Quaternion.Slerp(transform.rotation, snapTo.transform.rotation, Time.fixedDeltaTime * t * 2);
                }
            }
        }
    }

    public void setTouchedToFalse() {
        touched = false;
    }

    public bool getTouched() {
        return touched;
    }
    
}
