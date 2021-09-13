using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public enum SpellType {FIRE, ICE, THUNDER}

public class Spell : MonoBehaviour{
    public Impact impactPrefab;
    public SpellType spellType;

    public VisualEffect vfx;
    public bool useOffset;

    void Start(){
        if(vfx == null){
            vfx = GetComponent<VisualEffect>();
        }
    }
    
    void OnCollisionEnter(Collision other) {
        if(impactPrefab != null){
            Dummy dummy = other.collider.GetComponent<Dummy>();
            var dist = .5f;
            if(dummy != null){
                dist = 1;
            }
            var impactVFX = Instantiate(impactPrefab, other.contacts[0].point + other.contacts[0].normal * dist, Quaternion.identity);
            impactVFX.transform.rotation = Quaternion.FromToRotation(-transform.forward, other.contacts[0].normal) * transform.rotation;
            
            if (dummy != null) {
                impactVFX.anchorTo(dummy.decalsAnchor);
                impactVFX.transform.SetParent(dummy.decalsAnchor);
            }
        }
        Destroy(gameObject);
    }

    public void onThrowing(){
        if(vfx != null){
            var trailsSize = spellType switch {
                SpellType.THUNDER => .5f,
                SpellType.ICE => .1f,
                SpellType.FIRE => .5f,
                _ => 0,
            };

            vfx.SetFloat("TrailsSize", trailsSize);
        }
    }
}
