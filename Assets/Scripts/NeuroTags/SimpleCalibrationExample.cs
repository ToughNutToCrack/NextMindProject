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
    public List<GameObject> extraTags;
    
    void Start(){
        StartCoroutine(startCalibrationWhenReady());
    }

    private IEnumerator startCalibrationWhenReady(){
        yield return new WaitUntil(NeuroManager.Instance.IsReady);
        calibrationManager.onCalibrationResultsAvailable.AddListener(onReceivedResults);
        calibrationManager.StartCalibration();
    }

    private void onReceivedResults(Device device, CalibrationResults.CalibrationGrade grade){
        resultsText.text = $"Received results for {device.Name} with a grade of {grade}";
        foreach (var t in extraTags)
            t.SetActive(true);
    }
}
