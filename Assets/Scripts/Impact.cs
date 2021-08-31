using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Impact : MonoBehaviour{
    public DecalProjector decal;
    public float speed = 1;
    public float timeBeforeFade = 2;

    Material currentMaterial;
    float elapsedTime = 0;

    void Start() {
        Destroy(gameObject, timeBeforeFade * 2);
        Material mat = new Material(decal.material);
        decal.material = mat;
        currentMaterial = decal.material;
    }

    void Update(){
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= timeBeforeFade){
            var fadeValue = currentMaterial.GetFloat("_Fade");
            if(fadeValue <= 1){
                fadeValue += Time.deltaTime * speed;
                currentMaterial.SetFloat("_Fade", fadeValue);
            }
        }
    }
}
