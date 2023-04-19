using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disociacion : MonoBehaviour
{

    GameObject[] moleculasDisociadas;
    GameObject[] moleculasAguaSal;

    bool disociarMoleculas = false;

    // Start is called before the first frame update
    void Start()
    {
        moleculasDisociadas = GameObject.FindGameObjectsWithTag("moleculas_disociadas");
        moleculasAguaSal = GameObject.FindGameObjectsWithTag("molecula_agua_sal");

        //for each molecula
        foreach (GameObject molecula in moleculasDisociadas)
        {
            //try catch
            try
            {
                //desactivar molecula
                molecula.SetActive(false);
            }
            catch
            {
                //do nothing
            }
        }
        
    }

    // Update is called once per frame


    public void disociar(){
        if(!disociarMoleculas){
            disociarMoleculas = true;
            //for each moleculasAguaSal
            foreach (GameObject molecula in moleculasAguaSal)
            {
                //try catch
                try
                {
                    //activar molecula
                    molecula.SetActive(false);
                }
                catch
                {
                    //do nothing
                }
            }
            //for each moleculasDisociadas
            foreach (GameObject molecula in moleculasDisociadas)
            {
                //try catch
                try
                {
                    //activar molecula
                    molecula.SetActive(true);
                }
                catch
                {
                    //do nothing
                }
            }
        }else
        {
            disociarMoleculas = false;
            //for each moleculasAguaSal
            foreach (GameObject molecula in moleculasAguaSal)
            {
                //try catch
                try
                {
                    //activar molecula
                    molecula.SetActive(true);
                }
                catch
                {
                    //do nothing
                }
            }
            //for each moleculasDisociadas
            foreach (GameObject molecula in moleculasDisociadas)
            {
                //try catch
                try
                {
                    //activar molecula
                    molecula.SetActive(false);
                }
                catch
                {
                    //do nothing
                }
            }
        }
    }

    public void restar()
    {
        //restart scene
        Application.LoadLevel(Application.loadedLevel);
    }

}
