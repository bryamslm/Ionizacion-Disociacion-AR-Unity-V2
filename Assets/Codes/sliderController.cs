using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderController : MonoBehaviour
{
    public void OnSliderValueChanged(float value)
    {
        //find the objects with the tag "molecula"
        GameObject[] moleculasAgua = GameObject.FindGameObjectsWithTag("moleculasAgua");
        //for each molecula
        foreach (GameObject molecula in moleculasAgua)
        {
            //try catch
            try
            {
                //get the script
                movement script = molecula.GetComponent<movement>();
                //set the value
                script.velMov = value;
                script.velRot = value*100;
            }
            catch
            {
                //do nothing
            }
        }
        GameObject[] moleculasIonizadas = GameObject.FindGameObjectsWithTag("moleculasIonizadas");
        //for each molecula
        foreach (GameObject hidrogeno_agua in moleculasIonizadas)
        {
            //try catch
            try
            {
                //get the script
                movement script = hidrogeno_agua.GetComponent<movement>();
                //set the value
                script.velMov = value;
            }
            catch
            {
                //do nothing
            }
        }
        GameObject[] moleculas_agua_sal = GameObject.FindGameObjectsWithTag("molecula_agua_sal");
        //for each molecula
        foreach (GameObject molecula in moleculas_agua_sal)
        {
            //try catch
            try
            {
                //get the script
                movement script = molecula.GetComponent<movement>();
                //set the value
                script.velMov = value;
                script.velRot = value*100;
            }
            catch
            {
                //do nothing
            }
        }

        GameObject[] moleculas_disociadas = GameObject.FindGameObjectsWithTag("moleculas_disociadas");
        //for each molecula
        foreach (GameObject molecula in moleculas_disociadas)
        {
            //try catch
            try
            {
                //get the script
                movement script = molecula.GetComponent<movement>();
                //set the value
                script.velMov = value;
                script.velRot = value*100;
            }
            catch
            {
                //do nothing
            }
        }

        GameObject[] moleculasVinagre = GameObject.FindGameObjectsWithTag("moleculaVinagre");
        //for each molecula
        foreach (GameObject molecula in moleculasVinagre)
        {
            //try catch
            try
            {
                //get the script
                movement script = molecula.GetComponent<movement>();
                //set the value
                script.velMov = value;
                script.velRot = value*100;
            }
            catch
            {
                //do nothing
            }
        }

        GameObject[] moleculasSacarosa = GameObject.FindGameObjectsWithTag("moleculaSacarosa");
        //for each molecula
        foreach (GameObject molecula in moleculasVinagre)
        {
            //try catch
            try
            {
                //get the script
                movement script = molecula.GetComponent<movement>();
                //set the value
                script.velMov = value;
                script.velRot = value*100;
            }
            catch
            {
                //do nothing
            }
        }
    }
}
