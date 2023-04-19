using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;
using UnityEngine.AI;

public class SimpleMovement : MonoBehaviour
{
    public bool goRight = true;
    public float velMov = 0.30f;
    public float velRot = 30;
    public float tiempoReaccion = 2f;
    public int movimiento;
    public bool espera, gira;
    public ImageTargetBehaviour itb;
    public float distancia = 0.5f;

    public Vector3 posInicial; // Guardamos la posición inicial


    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position; // Guardamos la posición inicial
        GameObject padre = transform.parent.gameObject.transform.parent.gameObject;
        itb = padre.GetComponent<ImageTargetBehaviour>();
        int num = new System.Random().Next(0, 2);


        if (num == 0)
        {
            this.goRight = false;
        }

        
        accion();
    }

    // Update is called once per frame
    void Update()
    {

        //konow if object is being displayed
        if (itb.TargetStatus.Status.ToString() == "NO_POSE")
        {
            try{

                Destroy(GetComponent<SimpleMovement>());
               
            }
            catch{
                //do nothing
            }
            Debug.Log("NO_POSE UPDATE");
            return;
        }
        //know if object is being rendered (itb.TargetStatus.Status.ToString() == "TRACKED" || itb.TargetStatus.Status.ToString() == "EXTENDED_TRACKED")
        else
        {
        
            RaycastHit hit;
            //draw raycast
            Debug.DrawRay(transform.position, transform.forward * distancia, Color.red);
            if (Physics.Raycast(transform.position, transform.forward, out hit, distancia))
            {

                if (hit.collider)
                {
                    gira = true;
                    StartCoroutine(esperar()); // Espera 0.8 segundos y luego gira
                }
            }
            
            if (this.goRight && itb.TargetStatus.Status.ToString() != "NO_POSE")
            {
                transform.Rotate(new Vector3(-15f, 45f, -15f) * Time.deltaTime);

            }
            else
            {
                if(itb.TargetStatus.Status.ToString() != "NO_POSE")
                    transform.Rotate(new Vector3(15f, -45f, 15f) * Time.deltaTime);

            }
           
            transform.position += transform.forward * velMov * Time.deltaTime;


            if (gira && itb.TargetStatus.Status.ToString() != "NO_POSE")
            {
                transform.Rotate(Vector3.up * velRot * Time.deltaTime);
            }

        }

    }

    public void accion()
    {

        try
        {
            int num = new System.Random().Next(1, 3);
            movimiento = num;

            switch (movimiento)
            {
                case 2:

                    gira = true;

                    try
                    {
                        //if is active
                        if (itb.TargetStatus.Status.ToString() != "NO_POSE")
                        {
                            StartCoroutine(esperar()); // Espera 0.8 segundos y luego gira
                        }

                    }
                    catch
                    {
                        //do nothing
                    }
                    break;
            }

            if (itb.TargetStatus.Status.ToString() != "NO_POSE")
                Invoke("accion", 3f); // Llama a la función accion() cada 3 segundos
        }
        catch (Exception e)
        {
            //do nothing
        }

    }

    IEnumerator esperar()
    {
        if (itb.TargetStatus.Status.ToString() == "NO_POSE")
        {
            Debug.Log("NO_POSE ESPERAR");
            yield return new WaitForSeconds(0f);
        }
        else
        {
            yield return new WaitForSeconds(tiempoReaccion);
            gira = false;
        }

    }

    
}
