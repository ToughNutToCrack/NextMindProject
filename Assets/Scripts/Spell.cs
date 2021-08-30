using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour{
    public GameObject impactPrefab;

    void OnCollisionEnter(Collision other) {
        print(other.gameObject);
        Debug.DrawRay(other.contacts[0].point, other.contacts[0].normal * 3, Color.red, Mathf.Infinity);
        var impactVFX = Instantiate(impactPrefab, other.contacts[0].point - other.contacts[0].normal * .05f, Quaternion.identity);
        impactVFX.transform.rotation = Quaternion.FromToRotation(transform.up, other.contacts[0].normal) * transform.rotation;
        Destroy(gameObject);
    }
}
