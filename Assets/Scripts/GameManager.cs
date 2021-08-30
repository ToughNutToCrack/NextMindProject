using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePhase {NONE, TRAINING, STARTED}
public enum TrainingPhase {NONE, COMPLETE}

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

    public bool useNextMind = false;
    public GameObject neuroManager;
    public GameObject nextMindStatus;
    public GameObject calibrationCanvas;
    public CalibrationController calibrationController;
    public GameObject calibrationTags;

    [HideInInspector]
    public GamePhase gamePhase = GamePhase.NONE;
    [HideInInspector]
    public TrainingPhase trainingPhase = TrainingPhase.NONE;

    void Start() {
        neuroManager.SetActive(useNextMind); 
        nextMindStatus.SetActive(useNextMind); 
        calibrationCanvas.SetActive(useNextMind); 
        calibrationController.gameObject.SetActive(useNextMind); 
        calibrationTags.SetActive(useNextMind); 
    }

    public void startGame(){
        if(!useNextMind){
            gamePhase = GamePhase.STARTED;
        }else{
            gamePhase = GamePhase.TRAINING;
            calibrationController.startCalibration();
        }
    }

    public void onCalibrationEnd(){
        gamePhase = GamePhase.STARTED;
        trainingPhase = TrainingPhase.COMPLETE;
        // calibrationCanvas.SetActive(false);
    }

}
