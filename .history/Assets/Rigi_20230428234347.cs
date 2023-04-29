using UnityEngine;

public class BeatDetector : MonoBehaviour {
    private static BeatDetector instance;
    private float timeLastBeat;
    private float bpm;
    
    private BeatDetector() { }
    
    public static BeatDetector GetInstance() {
        if (instance == null) {
            instance = new BeatDetector();
        }
        return instance;
    }
    
    void Start() {
        timeLastBeat = Time.time;
    }
    
    void Update() {
        float deltaTime = Time.deltaTime;
        bpm = 60f / deltaTime;
        timeLastBeat += deltaTime;
    }
    
    public bool IsOnBeat(float beatOffset, float threshold) {
        float timeInterval = 60f / bpm;
        float expectedBeatTime = timeLastBeat - (timeLastBeat - beatOffset * timeInterval);
        float timeDifference = Mathf.Abs(Time.time - expectedBeatTime);
        return timeDifference <= threshold;
    }
}
