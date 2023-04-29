using UnityEngine;

public class BeatDetector : MonoBehaviour {
    private static BeatDetector instance;
    public float bpm = 60;
    
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
}
