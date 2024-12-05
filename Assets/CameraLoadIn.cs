using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraLoadIn : MonoBehaviour
{
    public PostProcessVolume PPV;
    Vignette v;
    LensDistortion ld;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Awake()
    {
        Debug.Log("test");
        StartCoroutine(CameraLoad());

    }
    IEnumerator CameraLoad()
    {

        v = PPV.profile.GetSetting<Vignette>(); //GetComponentInChildren<Vignette>();
        ld = PPV.profile.GetSetting<LensDistortion>();

        v.intensity.Override(0.9f);
        ld.intensity.Override(-70);
        while (v.intensity.value > 0.1f)
        {
            v.intensity.Override(v.intensity.value - 0.01f);
            //Debug.Log(v.intensity.value);
            ld.intensity.Override(ld.intensity.value + 0.75f);
            //Debug.Log(ld.intensity.value);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Debug.Log(v.intensity.value);
        v.intensity.Override(0f);
        ld.intensity.Override(0f);
    }
}
