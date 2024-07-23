using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Fog : MonoBehaviour {
    [Header("Fog")]
    public Shader fogShader;
    public Color fogColor;
    public Color fogDayColor;
    
    [Range(0.0f, 1.0f)]
    public float fogDensity;
    
    [Range(0.0f, 100.0f)]
    public float fogOffset;
    
    private Material fogMat;

    void Start() {
        if (fogMat == null) {
            fogMat = new Material(fogShader);
            fogMat.hideFlags = HideFlags.HideAndDontSave;
        }

        Camera cam = GetComponent<Camera>();
        cam.depthTextureMode = cam.depthTextureMode | DepthTextureMode.Depth;
        
        // hook itself up to bed trigger
        Bed.AfterSleepPhaseTrigger += setFogDay;
    }

    [ImageEffectOpaque]
    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        fogMat.SetVector("_FogColor", fogColor);
        fogMat.SetFloat("_FogDensity", fogDensity);
        fogMat.SetFloat("_FogOffset", fogOffset);
        Graphics.Blit(source, destination, fogMat);
    }
    
    void setFogDay() {
        Debug.Log("Fog color set");
        fogColor = fogDayColor;
    }
}