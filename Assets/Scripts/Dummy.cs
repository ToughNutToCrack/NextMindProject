using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Transform target;
    public Animator animator;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("hit");
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Spell")) {
            animator.SetTrigger("hit");
        }
    }
}
