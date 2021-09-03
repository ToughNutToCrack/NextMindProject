using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[ExecuteInEditMode]
[RequireComponent (typeof (DecalProjector))]
public class DecalsFadeAngle : MonoBehaviour{
    const string FW = "_Forward";
    DecalProjector decal;

    void Start(){
        decal = GetComponent<DecalProjector>();
        Material m = decal.material;
        if(m != null){
            m.SetVector(FW, transform.forward);
        }
    }


}
