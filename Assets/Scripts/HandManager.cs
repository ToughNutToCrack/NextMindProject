using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public float distanceThreshold = 0.2f;
    public int numberOfStep = 2;
    Vector3 oldTransform;
    int counter;
    public SpellManager spellManager;

    void Start()
    {
        oldTransform = transform.position;
    }

    void Update()
    {
        print(counter);
        if (counter >= numberOfStep)
            spellManager.ThrowSpell(transform.position - oldTransform);

        var distance = Vector3.Distance(transform.position, oldTransform);
        oldTransform = transform.position;

        if (distance > distanceThreshold)
            counter++;
        else 
            counter = 0;
    }
}
