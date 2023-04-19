using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class FlashController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetFlashLight(bool enabled)
    {
        VuforiaBehaviour vuforiaBehaviour = FindObjectOfType<VuforiaBehaviour>();
        vuforiaBehaviour.CameraDevice.SetFlash(enabled);
    }

    public void emiteLuz()
    {
        SetFlashLight(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
