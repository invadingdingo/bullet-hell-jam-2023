using UnityEngine;
using System.Collections;
using SynchronizerData;
using System;
using UnityEngine.Events;

public class BeatCounter : MonoBehaviour {

	public static BeatCounter instance;
	public BeatValue beatValue = BeatValue.EighthBeat;
	public float loopTime = 30f;
	public AudioSource audioSource;
	private float nextBeatSample;
	private float samplePeriod;
	private float sampleOffset;
	private float currentSample;

	public delegate void OnBeatEventHandler();
	public event OnBeatEventHandler OnBeatEvent;

	public void AddListener(OnBeatEventHandler listener) {
		OnBeatEvent += listener;
	}

	public void RemoveListener(OnBeatEventHandler listener) {
		OnBeatEvent -= listener;
	}
	
	void Awake () {
		// Calculate number of samples between each beat.
		instance = this;
		float audioBpm = audioSource.GetComponent<BeatSynchronizer>().bpm;
		samplePeriod = (60f / (audioBpm * BeatDecimalValues.values[(int)beatValue])) * audioSource.clip.frequency;
		nextBeatSample = 0f;
	}

	void Start () {
		
	}

	void StartBeatCheck (double syncTime) {
		nextBeatSample = (float)syncTime * audioSource.clip.frequency;
		StartCoroutine(BeatCheck());
	}
	
	void OnEnable () {
		BeatSynchronizer.OnAudioStart += StartBeatCheck;
	}

	void OnDisable () {
		BeatSynchronizer.OnAudioStart -= StartBeatCheck;
	}

	IEnumerator BeatCheck () {
		while (audioSource.isPlaying) {
			currentSample = (float)AudioSettings.dspTime * audioSource.clip.frequency;
			
			if (currentSample >= (nextBeatSample + sampleOffset)) {
				if (OnBeatEvent != null) // <- This is where the event is invoked.
					OnBeatEvent();
				nextBeatSample += samplePeriod;
			}

			yield return new WaitForSeconds(loopTime / 1000f);
		}
	}
}
