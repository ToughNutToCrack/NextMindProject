using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour{
    public GameObject impactPrefab;

    void OnCollisionEnter(Collision other) {
        var impactVFX = Instantiate(impactPrefab, other.contacts[0].point - other.contacts[0].normal * .05f, Quaternion.identity);
        impactVFX.transform.rotation = Quaternion.FromToRotation(transform.forward, other.contacts[0].normal) * transform.rotation;
        Destroy(gameObject);
    }
}
