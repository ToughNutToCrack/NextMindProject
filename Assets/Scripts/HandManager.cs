using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour{
    public Transform head;
    public OVRHand hand;
    public Transform spellSpwanPoint;
    public Vector3 offset;
    public GameManager gameManager;
    public List<GameObject> tags;
    [Header("Debug")]
    public GameObject spellPrefabDebug;

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
                if(gameManager.trainingPhase == TrainingPhase.COMPLETE){
                    setTagsActive(true);
                }else{
                    currentSpell = Instantiate(spellPrefabDebug, spellSpwanPoint.position, spellSpwanPoint.rotation);
                    currentSpell.transform.SetParent(spellSpwanPoint);
                    currentSpell.transform.localPosition += offset;
                }
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
            currentSpell.GetComponent<Spell>().onThrowing();
            currentSpell.transform.SetParent(null);
            Rigidbody rb = currentSpell.AddComponent<Rigidbody>();
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            // rb.AddForce(currentVelocity * 500);
            rb.velocity += currentVelocity  * 10;
            // print(currentVelocity);
            currentSpell = null;
            
        }
    }

    void setTagsActive(bool value){
        tags.ForEach( x => x.SetActive(value));
    }

    public void setActiveSpell(GameObject spellPrefab){
        if(currentSpell == null){
            setTagsActive(false);
            currentSpell = Instantiate(spellPrefab, spellSpwanPoint.position, spellSpwanPoint.rotation);
            currentSpell.transform.SetParent(spellSpwanPoint);
            currentSpell.transform.localPosition += offset;
        }
    }

}
