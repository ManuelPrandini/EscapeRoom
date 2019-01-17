using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOggettoTerzoTask : MonoBehaviour {

    public GameObject oggetto;

    private void OnTriggerEnter(Collider other)
    {
        if((other.name == oggetto.name+"(Clone)" || other.name == oggetto.name ) && TerzoTask.oggettoSpostato)
        {
            Gameplay.terzoTask = false;
            Gameplay.inizioQuartoTask = true;
            GameObject.Find("SaloneController").transform.GetChild(0).gameObject.SetActive(false);  //indica l'area di attivazione terzoTask
            TestoGioco.playTesto = true;
        }
    }
}
