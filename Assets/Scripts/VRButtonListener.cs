using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButtonListener : MonoBehaviour{

    public bool isGameStarted = false;

    void OnTriggerEnter(Collider other) {
        OVRHand hand = other.GetComponent<OVRHand>();
        if(hand != null){
            isGameStarted = true;
            gameObject.SetActive(false);
        }
    }
}
