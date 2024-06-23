using System;
using UnityEngine;

public class Ditherer : MonoBehaviour {
    public Shader ditherShader;

    [Range(0.0f, 1.0f)]
    public float spread = 0.5f;

    [Range(2, 10)]
    public int colorBits = 2;

    [Range(0, 2)]
    public int bayerLevel = 0;

    [Range(0, 8)]
    public int downSamples = 0;

    public bool pointFilterDown = false;

    private Material ditherMat;
    
    void OnEnable() {
        ditherMat = new Material(ditherShader);
        ditherMat.hideFlags = HideFlags.HideAndDontSave;
    }

    void OnDisable() {
        ditherMat = null;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        ditherMat.SetFloat("_Spread", spread);
        ditherMat.SetInt("_RedColorCount", (int)Mathf.Pow(2, colorBits));
        ditherMat.SetInt("_GreenColorCount", (int)Mathf.Pow(2, colorBits));
        ditherMat.SetInt("_BlueColorCount", (int)Mathf.Pow(2, colorBits));
        ditherMat.SetInt("_BayerLevel", bayerLevel);

        int width = source.width;
        int height = source.height;

        RenderTexture[] textures = new RenderTexture[8];

        RenderTexture currentSource = source;

        for (int i = 0; i < downSamples; ++i) {
            width /= 2;
            height /= 2;

            if (height < 2)
                break;

            RenderTexture currentDestination = textures[i] = RenderTexture.GetTemporary(width, height, 0, source.format);

            if (pointFilterDown)
                Graphics.Blit(currentSource, currentDestination, ditherMat, 1);
            else
                Graphics.Blit(currentSource, currentDestination);

            currentSource = currentDestination;
        }

        RenderTexture dither = RenderTexture.GetTemporary(width, height, 0, source.format);
        Graphics.Blit(currentSource, dither, ditherMat, 0);

        Graphics.Blit(dither, destination, ditherMat, 1);
        RenderTexture.ReleaseTemporary(dither);
        for (int i = 0; i < downSamples; ++i) {
            RenderTexture.ReleaseTemporary(textures[i]);
        }
    }
}