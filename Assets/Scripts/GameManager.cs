using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpellManager spellManager;

    public void StartExperience() {
        spellManager.ActivateSpells();
    }

}
