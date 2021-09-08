using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour{
    public GameObject spell;
    public float strength = 8;

    
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            throwSpell();
        }
    }

    void throwSpell(){
        var currentSpell = Instantiate(spell, transform.position, transform.rotation);
        currentSpell.GetComponent<Spell>().onThrowing();
        currentSpell.transform.SetParent(null);
        Rigidbody rb = currentSpell.AddComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;    
        rb.velocity += transform.forward  * strength;
    
    }
}
