using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    private ImageTargetBehaviour target;
    private bool first = true;

    [SerializeField] AudioSource audio;

    void Start()
    {
        target = GetComponent<ImageTargetBehaviour>();
    }

    public void dispararSonido(){
        
        if(!first){
            if(target.TargetStatus.Status.ToString() == "NO_POSE" ||
            target.TargetStatus.Status.ToString() == "EXTENDED_TRACKED"){

                Debug.Log("SE SUPONE QUE SUENO");
            
            //get audio source
            audio.Play();
        }
        }
        else{
            first = false;
        }
    
    }
}
