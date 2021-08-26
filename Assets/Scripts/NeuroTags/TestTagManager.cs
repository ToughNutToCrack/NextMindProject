using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using NextMind;
using NextMind.Devices;
using NextMind.Calibration;
using System.Collections.Generic;

public class TestTagManager : MonoBehaviour{
    public CalibrationManager calibrationManager;
    public Text resultsText;
    public List<GameObject> objectToUse;
    
    void Start(){
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
        resultsText.gameObject.SetActive(false);
        activateAll();
    }

    void activateAll(){
        objectToUse.ForEach( x => x.SetActive(true));
    }
}
