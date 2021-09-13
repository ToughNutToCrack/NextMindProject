using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour{
    public Transform head;
    public OVRHand hand;
    public Transform spellSpwanPoint;
    public Vector3 offset;
    public float strength = 8;
    [Space]
    public GameManager gameManager;
    public List<GameObject> tags;
    [Header("Debug")]
    public GameObject spellPrefabDebug;

    GameObject currentSpell = null;
    Vector3 previousPosition;
    Vector3 currentVelocity;
    Vector3 currentDirection;

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
                    if(currentSpell.GetComponent<Spell>().useOffset){
                        currentSpell.transform.localPosition += offset;
                    }
                }
            }
        }

        if(currentSpell != null){
            currentVelocity = calculateCurrentVelocity();
            currentDirection = calculateDirection();
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

    Vector3 calculateDirection(){
        var heading = currentSpell.transform.position - head.position;
        var distance = heading.magnitude;
        return heading/distance;
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "SpellBoxController" && currentSpell != null){
            currentSpell.GetComponent<Spell>().onThrowing();
            currentSpell.transform.SetParent(null);
            Rigidbody rb = currentSpell.AddComponent<Rigidbody>();
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.velocity += currentDirection * currentVelocity.magnitude * strength;
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
            if(currentSpell.GetComponent<Spell>().useOffset){
                currentSpell.transform.localPosition += offset;
            }
        }
    }

}
