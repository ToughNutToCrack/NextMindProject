using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[ExecuteInEditMode]
[RequireComponent (typeof (DecalProjector))]
public class DecalsFadeAngle : MonoBehaviour{
    const string FW = "_Forward";
    DecalProjector decal;
    Material currentMaterial;

    void Update(){
        if(decal == null){
            decal = GetComponent<DecalProjector>();
        }
        currentMaterial = decal.material;
        if(currentMaterial != null){
            currentMaterial.SetVector(FW, transform.forward);
        }
    }


}
