using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraEffects : MonoBehaviour
{
    public float lensDistortionIntensity;
    public float lensDistortionX;
    public float lensDistortionY;
    public float lensCenterY;
    public PostProcessVolume PPV;
    LensDistortion ld;
    // Start is called before the first frame update
    void Start()
    {
        ld = PPV.profile.GetSetting<LensDistortion>();
    }

    // Update is called once per frame
    void Update()
    {
        ld.intensity.Override(lensDistortionIntensity);
        ld.intensityY.Override(lensDistortionY);
        ld.centerY.Override(lensCenterY);
    }
}
