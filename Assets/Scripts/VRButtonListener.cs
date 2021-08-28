using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButtonListener : MonoBehaviour{

    public UnityEvent onTrigger;
    public bool autoTurnOff = false;

    void OnTriggerEnter(Collider other) {
        OVRHand hand = other.GetComponent<OVRHand>();
        if(hand != null && onTrigger != null){
            onTrigger.Invoke();
            gameObject.SetActive(!autoTurnOff);
        }
    }
}
