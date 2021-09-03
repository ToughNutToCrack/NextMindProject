using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Transform target;
    public Animator animator;
    public Transform decalsAnchor;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("hit");
    }

    void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Spell")) {
            animator.SetTrigger("hit");
        }
    }
}
