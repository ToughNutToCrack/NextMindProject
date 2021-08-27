using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    // public List<GameObject> runes;
    // public OVRHand OVRHand;
    // bool runesActive;
    // bool experienceStarted;
    // public List<GameObject> spells;
    // public Transform spellParent;
    // GameObject spawnedObject;
    // int n;

    // public void ActivateSpells() {
    //     experienceStarted = true;
    // }
    
    // void Update()
    // {        
    //     if (experienceStarted) {
    //         if (!runesActive && OVRHand.IsSystemGestureInProgress && spawnedObject == null)
    //         {
    //             runesActive = true;
    //             HandleRunes(runesActive);
    //         }
    //         else if (runesActive && !OVRHand.IsSystemGestureInProgress)
    //         {
    //             runesActive = false;
    //             HandleRunes(runesActive);
    //         }
    //     }
    // }

    // void HandleRunes(bool activate) {
    //     foreach (var r in runes)
    //         r.SetActive(activate);
    // }

    // public void ActivateSpell(int spellIndex) {
    //     HandleRunes(false);
    //     spawnedObject = Instantiate(spells[spellIndex], spellParent);
    // }

    // public void ThrowSpell(Vector3 direction) {
    //     if (spawnedObject != null)
    //     {
    //         spawnedObject.transform.parent = null;
    //         spawnedObject.GetComponent<Spell>().ThrowSpell(direction);
    //         spawnedObject = null;
    //     }
    // }
}
