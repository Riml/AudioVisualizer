using UnityEngine;
using System.Collections;

public class MoleculeVisualizer : MonoBehaviour {

	public int detail = 2048; // Level of detail of the audio information (samples)
	
	public float amplitude = 0.1f; // Audio level
	public float scaleMultiplier= 100f; // How much the visualizer will be scaled
	public GameObject visualizer; // Game object used as visualizer
	public GameObject[] moleculeGroups; // Groups to show/hide
	private Vector3 startScale; // Start scale of the visualizer

	// Use this for initialization
	void Start () {
        /* Default values
        detail = 2048;
		amplitude = 0.1f;
		scaleMultiplier = 100f;
        */
        startScale = transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		float[] info = new float[detail]; // intialize the array to hold a certain amount of information i.e. detail
		AudioListener.GetOutputData (info, 0); // populate the array with data from the audio listener
		float packagedData = 0.0f;

		for (int x = 0; x < info.Length; x++) {
			packagedData += System.Math.Abs (info[x]); // Assign the value of the audio output data to a value
		}

		for (int i = 1; i < moleculeGroups.Length; i++) {
			if (packagedData > (i * 50) + 50) {
				moleculeGroups [i].SetActive(true);
			} 
			else {
				moleculeGroups [i].SetActive(false);
			}
		}
		transform.localScale = updateVisualizerScale (packagedData);
	}

	// Get the amplitude and return the bar scale
	private Vector3 updateVisualizerScale(float audioLevel){
		float tempValue = (audioLevel/detail);
		return new Vector3 (startScale.x + (tempValue * scaleMultiplier), startScale.y + 
			(tempValue * scaleMultiplier), startScale.z + (tempValue * scaleMultiplier));
	}
}
