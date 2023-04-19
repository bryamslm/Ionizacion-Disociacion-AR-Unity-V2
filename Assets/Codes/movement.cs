using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    bool goRight = true;
    Vector3 posInicial;

    Vector3 rotInicial;
    GameObject padre;
    public ImageTargetBehaviour itb;
    public float velMov = 0.30f;
    public float velRot = 30;
    float tiempoReaccion = 2f;
    int movimiento;
    bool espera, camina, gira;

    //renderer var
    public Material material;
    public Material plusMaterial;
    public Material minusMaterial;

    public Material child1Material;
    public Material child2Material;

    public int numChild;
    public float distancia = 0.5f;


    // Start is called before the first frame update
    void Start()
    {

        posInicial = transform.position; // Guardamos la posición inicial

        rotInicial = transform.eulerAngles; // Guardamos la rotación inicial

        //get parent object
        padre = transform.parent.gameObject.transform.parent.gameObject;

        // cast to Vuforia Image Target Behaviour
        itb = padre.GetComponent<ImageTargetBehaviour>();

        int num = new System.Random().Next(0, 2);


        if (num == 0)
        {
            this.goRight = false;
        }

        //objet name
        try{
            child1Material = transform.GetChild(1).gameObject.GetComponent<Renderer>().material;
            child2Material = transform.GetChild(2).gameObject.GetComponent<Renderer>().material;

        }
        catch
        {

        }
        //try catch block
        try
        {
            //get child object
            GameObject child0 = transform.GetChild(0).gameObject;
            GameObject child1 = transform.GetChild(1).gameObject;
            GameObject child2 = transform.GetChild(2).gameObject;

            //remove rigidbody to child0
            Destroy(child0.GetComponent<Rigidbody>());
            Destroy(child1.GetComponent<Rigidbody>());
            Destroy(child2.GetComponent<Rigidbody>());

            //remove collider to child0
            Destroy(child0.GetComponent<Collider>());
            Destroy(child1.GetComponent<Collider>());
            Destroy(child2.GetComponent<Collider>());

            //remove script movement to child0
            Destroy(child0.GetComponent<movement>());
            Destroy(child1.GetComponent<movement>());
            Destroy(child2.GetComponent<movement>());
        }
        catch
        {

        }
        accion();
    }

    // Update is called once per frame
    void Update()
    {

        //konow if object is being displayed
        if (itb.TargetStatus.Status.ToString() == "NO_POSE")
        {
            //set itself position
            transform.position = posInicial;

            //set itself rotation
            transform.eulerAngles = rotInicial;


            //transform.position = posInicial;
            return;
        }
        //know if object is being rendered (itb.TargetStatus.Status.ToString() == "TRACKED" || itb.TargetStatus.Status.ToString() == "EXTENDED_TRACKED")
        else
        {
            //get rigidbody
            Rigidbody rb = GetComponent<Rigidbody>();

            //get if object is being rendered
            RaycastHit hit;
            //draw raycast
            Debug.DrawRay(transform.position, transform.forward * distancia, Color.red);
            if (Physics.Raycast(transform.position, transform.forward, out hit, distancia))
            {

                if (hit.collider)
                {
                    gira = true;
                    if (itb.TargetStatus.Status.ToString() == "NO_POSE")
                    {
                        return;
                    }
                    StartCoroutine(esperar()); // Espera 0.8 segundos y luego gira
                }
            }
            if (itb.TargetStatus.Status.ToString() == "NO_POSE")
            {
                return;
            }
            if (this.goRight)
            {
                transform.Rotate(new Vector3(-15f, 45f, -15f) * Time.deltaTime);

            }
            else
            {
                transform.Rotate(new Vector3(15f, -45f, 15f) * Time.deltaTime);


            }
            if (itb.TargetStatus.Status.ToString() == "NO_POSE")
            {
                return;
            }
            transform.position += transform.forward * velMov * Time.deltaTime;
            if (itb.TargetStatus.Status.ToString() == "TRACKED")
            {
                posInicial = transform.position; // Guardamos la posición actual
                rotInicial = transform.eulerAngles; // Guardamos la rotación actual
            }


            if (gira)
            {
                transform.Rotate(Vector3.up * velRot * Time.deltaTime);
            }

        }

    }

    void accion()
    {

        try
        {
            int num = new System.Random().Next(1, 3);
            movimiento = num;

            switch (movimiento)
            {
                case 2:

                    gira = true;
                    if (itb.TargetStatus.Status.ToString() == "NO_POSE")
                    {
                        break;
                    }

                    try
                    {
                        //if is active
                        if (gameObject.activeSelf)
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
            yield return new WaitForSeconds(0f);
        }
        else
        {
            yield return new WaitForSeconds(tiempoReaccion);
            gira = false;
        }

    }


}

