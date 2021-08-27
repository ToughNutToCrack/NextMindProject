using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour{
    // public float speed = 2;
    // int n;
    // public void ThrowSpell(Vector3 direction) {
    //     StartCoroutine(MoveSpellToDirection(direction));
    // }
    // IEnumerator MoveSpellToDirection(Vector3 direction) {
    //     n++;
    //     while (n < 100)
    //     {
    //         transform.position = transform.position + direction.normalized * Time.deltaTime * speed;
    //         yield return null;
    //     }
    //     if (n >= 100)
    //         Destroy(gameObject);
    // }
    void OnCollisionEnter(Collision other) {
        print(other.gameObject);
    }
}
