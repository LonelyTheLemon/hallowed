using UnityEngine;

public class GameManager : MonoBehaviour {
    Color nightColor = new Color(3 / 255, 3 / 255, 5 / 255, 1);
    Color dayColor = new Color(1, 1, 1, 1);
    [SerializeField] Transform[] lightObjects;
    
    void Start() {
        setLightNight();
    }
    
    void setLightNight() {
        foreach(Transform lightObject in lightObjects) {
            Light light = lightObject.gameObject.GetComponent<Light>();
            if(light != null) {
                light.color = nightColor;
            }
        }
    }
}
