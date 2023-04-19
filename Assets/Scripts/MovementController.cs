using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;


public class MovementController : MonoBehaviour
{

    //gameobjects list
    public List<GameObject> gameObjects = new List<GameObject>();
    public List<SimpleMovement> movementScripts = new List<SimpleMovement>();
    public ImageTargetBehaviour itb;
    public GameObject ballModel;

    // Start is called before the first frame update
    void Start()
    {
        itb = GetComponent<ImageTargetBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(itb.TargetStatus.Status.ToString() == "NO_POSE")
        {
            //find objects by tag
            GameObject[] objects = GameObject.FindGameObjectsWithTag("moleculaSacarosa");
            foreach(GameObject obj in objects)
            {
                //destroy scripts
                SimpleMovement script = obj.GetComponent<SimpleMovement>();

                gameObjects.Add(obj);
                movementScripts.Add(script);
                Destroy(obj.GetComponent<SimpleMovement>());
                
            }
        }
        
        if(itb.TargetStatus.Status.ToString() == "TRACKED" || itb.TargetStatus.Status.ToString() == "EXTENDED_TRACKED")
        {
            //for i in gameObjects
            for(int i = 0; i < gameObjects.Count; i++)
            {
                //add script
                gameObjects[i].AddComponent<SimpleMovement>();
                gameObjects[i].GetComponent<SimpleMovement>().velMov = movementScripts[i].velMov;
                gameObjects[i].GetComponent<SimpleMovement>().velRot = movementScripts[i].velRot;
                gameObjects[i].GetComponent<SimpleMovement>().tiempoReaccion = movementScripts[i].tiempoReaccion;
                gameObjects[i].GetComponent<SimpleMovement>().movimiento = movementScripts[i].movimiento;
                gameObjects[i].GetComponent<SimpleMovement>().espera = movementScripts[i].espera;
                gameObjects[i].GetComponent<SimpleMovement>().gira = movementScripts[i].gira;
                gameObjects[i].GetComponent<SimpleMovement>().itb = movementScripts[i].itb;
                gameObjects[i].GetComponent<SimpleMovement>().distancia = movementScripts[i].distancia;
                gameObjects[i].GetComponent<SimpleMovement>().posInicial = movementScripts[i].posInicial;
                gameObjects[i].GetComponent<SimpleMovement>().goRight = movementScripts[i].goRight;
                gameObjects[i].GetComponent<SimpleMovement>().accion();
            }
        }
        
    }
}
