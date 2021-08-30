using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using NextMind;
using NextMind.Devices;
using NextMind.Calibration;
using System.Collections.Generic;

public class CalibrationController : MonoBehaviour{
    public CalibrationManager calibrationManager;
    public Text resultsText;
    public List<GameObject> calibrationTags;
    public UnityEvent onCalibrationEnd;
    [Header("Debug")]
    public bool autoStart = false;
    public List<GameObject> objectToUse;

    void Start(){
        if(autoStart){
            startCalibration();
        }
    }
    
    public void startCalibration(){
        calibrationTags.ForEach( x => x.SetActive(true));
        StartCoroutine(startCalibrationWhenReady());
    }

    IEnumerator startCalibrationWhenReady(){
        yield return new WaitUntil(NeuroManager.Instance.IsReady);
        calibrationManager.onCalibrationResultsAvailable.AddListener(onReceivedResults);
        calibrationManager.StartCalibration();
        resultsText.text = "";
    }

    void onReceivedResults(Device device, CalibrationResults.CalibrationGrade grade){
        resultsText.gameObject.SetActive(true);
        resultsText.text = $"Configuration complete! Received results for {device.Name} with a grade of {grade}";
        StartCoroutine(closeTextAndStartTest());
    }

    IEnumerator closeTextAndStartTest(){
        yield return new WaitForSeconds(3);
        if(onCalibrationEnd != null){
            onCalibrationEnd.Invoke();
        }
    }

    public void activateAll(){
        resultsText.gameObject.SetActive(false);
        objectToUse.ForEach( x => x.SetActive(true));
    }
}
