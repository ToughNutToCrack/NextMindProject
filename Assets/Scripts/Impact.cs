using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Impact : MonoBehaviour{
    const string FADE = "_Fade";
    public DecalProjector decal;
    public float speed = 1;
    public float timeBeforeDecal = 0;
    public float timeBeforeFade = 2;

    Material currentMaterial;
    float elapsedTime = 0;

    void Start() {
        Destroy(gameObject, timeBeforeDecal + timeBeforeFade * 2);
        Material mat = new Material(decal.material);
        decal.material = mat;
        currentMaterial = decal.material;
        currentMaterial.SetFloat(FADE, 1);
    }

    void Update(){
        elapsedTime += Time.deltaTime;
        if(elapsedTime > timeBeforeDecal && elapsedTime < timeBeforeDecal + timeBeforeFade){
            currentMaterial.SetFloat(FADE, .1f);
        }
        if(elapsedTime >= timeBeforeDecal + timeBeforeFade){
            var fadeValue = currentMaterial.GetFloat(FADE);
            if(fadeValue <= 1){
                fadeValue += Time.deltaTime * speed;
                currentMaterial.SetFloat(FADE, fadeValue);
            }
        }
    }
}
