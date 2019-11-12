using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    public Collider myTrigger;

    public float bonusJumpIntensity = 0.5f;
    public float bonusSpeed = 1;

    public UnityEvent onPickup;

    // Start is called before the first frame update
    void Start()
    {
        if (myTrigger == null) myTrigger = gameObject.GetComponent<Collider>();
        if (!myTrigger.isTrigger) myTrigger.isTrigger = true;
        myTrigger.gameObject.tag = "Pickup";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var playerControler = other.transform.root.GetComponent<PlayerControler>();

            playerControler.jumpIntensity += bonusJumpIntensity;
            playerControler.speed += bonusSpeed;

            onPickup.Invoke();
        }
    }
}
