using UnityEngine;
using System.Collections;

public class ColourChange : MonoBehaviour {

	public Color[] colours; // Holds the colours to lerp between
	public int currentIndex = 0; // Current colour index
	private int nextIndex; // next colour index
	public float changeTime = 2.0f; // time between one colour and the next
	private float timer = 0.0f; // for stepping

	void Start() {
		nextIndex = (currentIndex + 1) % colours.Length;
	}

	void Update() {
		timer += Time.deltaTime;

		if (timer > changeTime) {
			currentIndex = (currentIndex + 1) % colours.Length;
			nextIndex = (currentIndex + 1) % colours.Length;
			timer = 0.0f;
		}
		foreach (Renderer r in GetComponentsInChildren<Renderer>()) {
			r.material.color = Color.Lerp (colours [currentIndex], colours [nextIndex], timer / changeTime);
		}
	}
}