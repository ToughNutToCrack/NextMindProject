using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour{
    public GameObject spell;
    public List<GameObject> spells;
    public bool randomize;
    public float strength = 8;

    
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            throwSpell();
        }
    }

    void throwSpell(){
        var selectedSpell = spell;
        if(randomize){
            selectedSpell = spells[Random.Range(0,3)];
        }
        var currentSpell = Instantiate(selectedSpell, transform.position, transform.rotation);
        currentSpell.GetComponent<Spell>().onThrowing();
        currentSpell.transform.SetParent(null);
        Rigidbody rb = currentSpell.AddComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;    
        rb.velocity += transform.forward  * strength;
    
    }
}
