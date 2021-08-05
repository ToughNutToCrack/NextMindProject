using NextMind.NeuroTags;
using UnityEngine;
using UnityEngine.UI;

public class ConfidenceLevel : MonoBehaviour {
    public NeuroTag neuroTag;
    public Text prompt;

    public void Awake() {
        neuroTag.onConfidenceChanged.AddListener(onChange);
    }
    
    public void onChange(float level){
        print($"{neuroTag.name} {level}");
        if(level > .6f){
            prompt.text = neuroTag.name;
        }
    }
}