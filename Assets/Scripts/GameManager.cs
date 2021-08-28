using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePhase {NONE, TRAINING, STARTED}

public class GameManager : MonoBehaviour{
    // public SpellManager spellManager;
    // public List<Transform> dummiesPositions;
    // public GameObject dummy;

    // public void StartExperience() {
    //     spellManager.ActivateSpells();
    //     for(int i = 0; i < dummiesPositions.Count; i++)
    //     {
    //         Instantiate(dummy, dummiesPositions[i].position, dummiesPositions[i].rotation);
    //     }
    // }

    public bool isGameStarted = false;

    public void startGame(){
        isGameStarted = true;
    }

}
