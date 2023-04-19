using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralFuntions : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
   

    public void Restart()
    {
        //restart scene
        Application.LoadLevel(Application.loadedLevel);
    }

    //exit application
    public void Exit()
    {
        Application.Quit();
    }
}
