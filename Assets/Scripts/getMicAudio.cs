using UnityEngine;
using System.Collections;

//set dependency (i.e. this needs an audio source) 
[RequireComponent(typeof(AudioSource))]

public class getMicAudio : MonoBehaviour
{

    public AudioSource audio;
    public int audioSamplesToTake = 64;
    public int audioSampleChannels = 0; //1=mono, 2=stereo, etc.
    private string audioOutDevice;
    private int minAudioFreq;
    private int maxAudioFreq;
    private float recTimer = 0;
    private float recRefreshTime = 10;
    public float audioListenerSensitivity;
    public float audioVolume;
    private bool isThereDevice = false;

    // Use this for initialization
    void Start()
    {
        //getting audio source
        audio = GetComponent<AudioSource>();

        //getting audio device
        try
        {
            audioOutDevice = Microphone.devices[0].ToString(); //array used in case there is more than one device
            Microphone.GetDeviceCaps(audioOutDevice, out minAudioFreq, out maxAudioFreq);
            Debug.Log(audioOutDevice);
        }
        catch
        {
            Debug.Log("No audio device");
        }

        if (audioOutDevice != null)
        {
            isThereDevice = true;
        }

        //start recording
        //null returns default device
        audio.clip = Microphone.Start(audioOutDevice, true, 10, 44100);

        audio.loop = true; //reusing audio clip, setting it to loop
        //audio.mute = true; //mute to avoid overlapping audio
        while (!(Microphone.GetPosition(audioOutDevice) > 0)) { } //wait for sound (gets sample position of mic)
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {

        //make sure there is input 
        if (isThereDevice == true)
        {

            //timer until renewing the recording
            recTimer += Time.deltaTime;

            if (recTimer >= recRefreshTime)
            {
                StopRecording();
                StartRecording();
                recTimer = 0;
            }
        }

        //for simplicity's sake, this allows for tweaking of input sound
        audioVolume = NormalizeAudio() * audioListenerSensitivity;
    }

    //Begin mic recording into audio clip, replacing old clip
    void StartRecording()
    {
        audio.clip = Microphone.Start(audioOutDevice, true, 10, 44100);
        while (!(Microphone.GetPosition(audioOutDevice) > 0)) { } //wait for sound
        audio.Play();
    }

    //Stop mic recording (to allow for new audio clip)
    void StopRecording()
    {
        audio.Stop();
        Microphone.End(audioOutDevice);
    }

    float NormalizeAudio()
    {

        //take and store samples
        float[] outputData = new float[audioSamplesToTake];
        float s = 0;
        audio.GetOutputData(outputData, audioSampleChannels);

        //finding the average of the samples
        foreach (float i in outputData)
        {
            s += Mathf.Abs(i);
        }

        return s / audioSamplesToTake;
    }
}
