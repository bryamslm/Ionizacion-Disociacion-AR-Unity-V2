using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class azucarController : MonoBehaviour
{
    [SerializeField] public GameObject azucar_macro;
    [SerializeField] public GameObject azucar_micro;
    [SerializeField] public GameObject marco_macro;
    [SerializeField] public GameObject marco_micro;
    [SerializeField] public GameObject macro;
 
    private bool activeMacro = true;
    // Start is called before the first frame update
    
    public void cargarModelo(){
        if (activeMacro){
            azucar_macro.SetActive(false);
            macro.SetActive(false);
            marco_macro.SetActive(false);
            marco_micro.SetActive(true);
            azucar_micro.SetActive(true);

        } else {
            azucar_macro.SetActive(true);
            azucar_micro.SetActive(false);
            marco_macro.SetActive(true);
            marco_micro.SetActive(false);
            macro.SetActive(true);
        }
        activeMacro = !activeMacro;
    }
}
