using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ionization : MonoBehaviour
{   
    GameObject[] moleculasIonizadas;

    GameObject[] moleculasAgua;
    bool ionizarMoleculas = false;
    
    void Start()
    {
        moleculasIonizadas = GameObject.FindGameObjectsWithTag("moleculasIonizadas");
        moleculasAgua = GameObject.FindGameObjectsWithTag("moleculasAgua");

        //for each molecula
        foreach (GameObject molecula in moleculasIonizadas)
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

    public void ionizar(){
        if(!ionizarMoleculas){
            ionizarMoleculas = true;
            //for each moleculasAguaSal
            foreach (GameObject molecula in moleculasAgua)
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
            foreach (GameObject molecula in moleculasIonizadas)
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
            ionizarMoleculas = false;
            //for each moleculasAguaSal
            foreach (GameObject molecula in moleculasAgua)
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
            foreach (GameObject molecula in moleculasIonizadas)
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