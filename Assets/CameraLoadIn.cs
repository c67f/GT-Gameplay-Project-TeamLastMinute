using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraLoadIn : MonoBehaviour
{
    public PostProcessVolume PPV;
    Vignette v;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        //StartCoroutine(CameraLoad);
    }
    /*IEnumerator CameraLoad()
    {
        v = PPV.GetComponent<Vignette>();
        v.intensity.value = 70.0f;
        while (v.intensity.value > 0.1)
        {
            v.intensity.value -= 1f;
            retu
        }
        v.intensity.value = 0;
    }*/
}
