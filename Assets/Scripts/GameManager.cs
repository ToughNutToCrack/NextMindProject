using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePhase {NONE, TRAINING, STARTED}
public enum TrainingPhase {NONE, COMPLETE}

public class GameManager : MonoBehaviour{
    

    // public void StartExperience() {
    //     spellManager.ActivateSpells();
    //     for(int i = 0; i < dummiesPositions.Count; i++)
    //     {
    //         Instantiate(dummy, dummiesPositions[i].position, dummiesPositions[i].rotation);
    //     }
    // }

    [Header("NextMind")]
    public bool useNextMind = false;
    public GameObject neuroManager;
    public GameObject nextMindStatus;
    public GameObject calibrationCanvas;
    public CalibrationController calibrationController;
    public GameObject calibrationTags;

    [Header("Enemies and Obstacles")]
    public Transform enemiesAndObstaclesParent;
    [Space]
    public bool useDummies = true;
    public GameObject dummy;
    public List<Transform> dummiesPositions;
    [Space]
    public bool useWall = false;
    public GameObject wall;
    

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
            onGameStarted();
        }else{
            gamePhase = GamePhase.TRAINING;
            calibrationController.startCalibration();
        }
    }

    public void onCalibrationEnd(){
        trainingPhase = TrainingPhase.COMPLETE;
        calibrationCanvas.SetActive(false);
        calibrationTags.SetActive(false); 
        onGameStarted();
    }

    void onGameStarted(){
        gamePhase = GamePhase.STARTED;
        wall.SetActive(useWall);

        if(useDummies){
            for(int i = 0; i < dummiesPositions.Count; i++){
                var d = Instantiate(dummy, dummiesPositions[i].position, dummiesPositions[i].rotation);
                d.transform.SetParent(enemiesAndObstaclesParent);
            }
        }
    }

}
