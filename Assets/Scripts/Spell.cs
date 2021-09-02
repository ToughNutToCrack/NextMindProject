using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public enum SpellType {FIRE, ICE, THUNDER}

public class Spell : MonoBehaviour{
    public GameObject impactPrefab;
    public SpellType spellType;

    public VisualEffect vfx;

    void Start(){
        if(vfx == null){
            vfx = GetComponent<VisualEffect>();
        }
    }
    
    void OnCollisionEnter(Collision other) {
        var impactVFX = Instantiate(impactPrefab, other.contacts[0].point - other.contacts[0].normal * .05f, Quaternion.identity);
        impactVFX.transform.rotation = Quaternion.FromToRotation(transform.forward, other.contacts[0].normal) * transform.rotation;
        Destroy(gameObject);
    }

    public void onThrowing(){
        if(vfx != null){
            var trailsSize = spellType switch {
                SpellType.THUNDER => .5f,
                SpellType.ICE => .7f,
                SpellType.FIRE => .5f,
                _ => 0,
            };

            vfx.SetFloat("TrailsSize", trailsSize);
        }
    }
}
