using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour{
    // public float distanceThreshold = 0.2f;
    // public int numberOfStep = 2;
    // Vector3 oldTransform;
    // int counter;
    // public SpellManager spellManager;
    // public OVRHand hand;

    // void Start(){
    //     oldTransform = transform.position;
    // }

    // void Update(){
    //     if (!hand.IsTracked){
    //         counter = 0;
    //         return;
    //     }

    //     var distance = Vector3.Distance(transform.position, oldTransform);

    //     if (distance > distanceThreshold){
    //         counter++;
    //         if (counter >= numberOfStep)
    //             spellManager.ThrowSpell(transform.position - oldTransform);
    //     }else{
    //         counter = 0;
    //     } 

    //     oldTransform = transform.position;
    // }

    public Transform head;
    public OVRHand hand;
    public Transform spellSpwanPoint;
    [Header("Debug")]
    public GameObject spellPrefab;
    public VRButtonListener buttonListener;

    GameObject currentSpell = null;
    Vector3 previousPosition;
    Vector3 currentVelocity;

    void Start() {
        previousPosition = transform.position;    
    }

    bool openHand() => hand.IsSystemGestureInProgress;

    void Update(){
        if(buttonListener.isGameStarted){
            if(openHand() && currentSpell == null){
                currentSpell = Instantiate(spellPrefab, spellSpwanPoint);
            }
        }

        if(currentSpell != null){
            currentVelocity = calculateCurrentVelocity();
            // print(currentVelocity);
            // printDistanceFromHead();
        }
    }

    Vector3 calculateCurrentVelocity(){
        Vector3 velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
        return velocity;
    }

    void printDistanceFromHead(){
        var heading = currentSpell.transform.position - head.position;
        var distance = heading.magnitude;
        print(distance);
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "SpellBoxController" && currentSpell != null){
            currentSpell.transform.SetParent(null);
            Rigidbody rb = currentSpell.AddComponent<Rigidbody>();
            print(currentVelocity);
            rb.AddForce(currentVelocity * 500);
            currentSpell = null;
        }
    }

}
