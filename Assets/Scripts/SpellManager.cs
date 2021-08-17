using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public List<GameObject> runes;
    public OVRHand OVRHand;
    bool runesActive;
    bool experienceStarted;
    public List<GameObject> spells;
    public Transform spellParent;

    public void ActivateSpells() {
        experienceStarted = true;
    }
    
    void Update()
    {        
        if (experienceStarted) {
            if (!runesActive && OVRHand.IsSystemGestureInProgress)
            {
                runesActive = true;
                HandleRunes(runesActive);
            }
            else if (runesActive && !OVRHand.IsSystemGestureInProgress)
            {
                runesActive = false;
                HandleRunes(runesActive);
            }
        }
    }

    void HandleRunes(bool activate) {
        foreach (var r in runes)
            r.SetActive(activate);
    }

    public void ActivateSpell(int spellIndex) {
        HandleRunes(false);
        var spell = Instantiate(spells[spellIndex], spellParent);
    }
}
