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
    public GameManager gameManager;
    [Header("Debug")]
    public GameObject spellPrefab;

    GameObject currentSpell = null; //observable patterns??
    Vector3 previousPosition;
    Vector3 currentVelocity;

    void Start() {
        previousPosition = transform.position;    
    }

    bool openHand() => hand.IsSystemGestureInProgress;

    void Update(){
        if(gameManager.gamePhase == GamePhase.STARTED){
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
            if (Vector3.Dot(head.forward, currentVelocity) < 0){
                print("back");
            }else{
                print(currentVelocity);
                currentSpell = null;
                rb.AddForce(currentVelocity * 500);

            }
        }
    }

}
