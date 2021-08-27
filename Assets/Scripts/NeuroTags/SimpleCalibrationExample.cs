using UnityEngine;
using System.Collections;
using NextMind;
using NextMind.Calibration;
using UnityEngine.UI;
using NextMind.Devices;
using System.Collections.Generic;

public class SimpleCalibrationExample : MonoBehaviour{
    public CalibrationManager calibrationManager;
    public Text resultsText;
    public GameManager manager;
    
    void Start(){
        StartCoroutine(startCalibrationWhenReady());
    }

    private IEnumerator startCalibrationWhenReady(){
        yield return new WaitUntil(NeuroManager.Instance.IsReady);
        calibrationManager.onCalibrationResultsAvailable.AddListener(onReceivedResults);
        calibrationManager.StartCalibration();
        resultsText.gameObject.SetActive(false);
    }

    private void onReceivedResults(Device device, CalibrationResults.CalibrationGrade grade){
        resultsText.gameObject.SetActive(true);
        resultsText.text = $"Configuration complete! Received results for {device.Name} with a grade of {grade}";
        // manager.StartExperience();
        StartCoroutine(closeText());
    }

    private IEnumerator closeText(){
        yield return new WaitForSeconds(3);
        resultsText.gameObject.SetActive(false);
    }
}
