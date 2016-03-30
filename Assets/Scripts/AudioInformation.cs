using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioInformation : MonoBehaviour
{

    public AudioSource audio;       // Audio to be listened to
    public Text display;            // GUIText to show results
    int qSamples = 2048;            // array size for sample resolution
    float refValue = 0.1f;          // RMS value for 0 dB
    float rmsValue;                 // sound level - RMS
    private float[] samples;        // amount of audio samples to take
    private float fSample;          // Stores the audio sample rate

    void Start()
    {
        samples = new float[qSamples];
        fSample = AudioSettings.outputSampleRate;
    }

    void AnalyzeSound()
    {
        if (audio != null)
        {
            audio.GetOutputData(samples, 0); // fill array with samples
            float sum = 0;
            for (int i = 0; i < qSamples; i++)
            {
                sum += samples[i] * samples[i]; // sum squared samples
            }

            rmsValue = Mathf.Sqrt(sum / qSamples); // rms = square root of average
        }
    }

    void Update()
    {
        AnalyzeSound();
        if (display)
        {
            display.text = "RMS: " + rmsValue.ToString("F2");
        }
    }
}