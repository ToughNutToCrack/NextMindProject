using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public float distanceThreshold = 0.2f;
    public int numberOfStep = 2;
    Vector3 oldTransform;
    int counter;
    public SpellManager spellManager;
    public OVRHand hand;
    // List<Vector3> positions;



    void Start()
    {
        // positions = new List<Vector3>();
        oldTransform = transform.position;
    }

    void Update()
    {
        if (!hand.IsTracked)
        {
            counter = 0;
            return;
        }

        var distance = Vector3.Distance(transform.position, oldTransform);

        if (distance > distanceThreshold)
        {
            counter++;
            if (counter >= numberOfStep)
                spellManager.ThrowSpell(transform.position - oldTransform);
        }
        else
        {
            counter = 0;
        } 

        oldTransform = transform.position;
    }
}
