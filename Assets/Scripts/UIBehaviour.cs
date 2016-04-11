using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour {


    public AudioSource aSource;
    public GameObject molecluo;
    private bool micAsSource=false;
    private int currentVisualizer = 0;
    private float audioMultiplier = 1;
    public Text sensText;
    public AudioClip audioClip;


    void Start() {
        UpdateSensitivity();
    }

    void UpdateSensitivity() {

        aSource.GetComponent<LineVisualizer>().amplitudeMultiplier = audioMultiplier;
        molecluo.GetComponent<MoleculeVisualizer>().amplitudeMultiplier = audioMultiplier;
        sensText.text = System.Math.Round(audioMultiplier,2).ToString();
    }

    
    public void SwitchInput()
    {
        if (micAsSource)
        {
            aSource.GetComponent<getMicAudio>().StartRecording();
            aSource.GetComponent<getMicAudio>().micIsActive = true;
           
        }
        else {
            aSource.GetComponent<getMicAudio>().StopRecording();
            aSource.GetComponent<getMicAudio>().micIsActive = false;
            aSource.clip = audioClip;
            aSource.Play();
        }
        micAsSource = !micAsSource;

    }
    
    public void increaseSensitivy() {
        audioMultiplier=audioMultiplier*1.1f;
        UpdateSensitivity();
    }

    public void decreaseSensitivy()
    {
        audioMultiplier=audioMultiplier/1.1f;
        UpdateSensitivity();
    }


    public void SwitchVisualizer()
    {

        currentVisualizer++;
        switch (currentVisualizer) {
            case 0:
                molecluo.SetActive(false);
                aSource.GetComponent<LineVisualizer>().enabled = true;
                aSource.GetComponent<LineRenderer>().enabled = true;
                break;
            case 1:
                molecluo.SetActive(true);
                aSource.GetComponent<LineVisualizer>().enabled = false;
                aSource.GetComponent<LineRenderer>().enabled = false;
                currentVisualizer = -1;
                break;
        }
       
    }

}
