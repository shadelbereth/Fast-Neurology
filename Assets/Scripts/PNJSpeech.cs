using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PNJSpeech : MonoBehaviour {

    public string speech;
    public Text speechText;
    private float waiting;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   if (speechText.text != null) {
            if (waiting > 0) {
                waiting -= Time.deltaTime;
            }
            else {
                speechText.text = null;
            }
       }
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            speechText.text = speech;
            waiting = 1;
        }
    }
}