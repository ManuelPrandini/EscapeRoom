using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnChiave : MonoBehaviour {

    public GameObject chiaveCamera;
    public GameObject chiaveBagni;
    //le chiavi per aprire cameretta e ufficio
    public GameObject chiaveRossa;
    public GameObject chiaveVerde;
    public GameObject chiaveBlu;

    private bool b_chiaveBagni = false;
    private bool b_chiaviUffCameretta = false;
    public Transform[] posChiaveCamera;
    public Transform[] posChiaveBagni;
    public Transform[] posRossa;
    public Transform[] posVerde;
    public Transform[] posBlu;



    private int sceltaPosizione;

	
	void Start () {
        //per il primo Task
        GeneraChiave(chiaveCamera, posChiaveCamera);

    }

    private void Update()
    {
        //per i task successivi
        if (Gameplay.inizioQuartoTask && !b_chiaveBagni)
        {
            GeneraChiave(chiaveBagni, posChiaveBagni);
            b_chiaveBagni = true;
        }
        
        if(Gameplay.inizioQuintoTask && !b_chiaviUffCameretta)
        {
            GeneraChiave(chiaveRossa, posRossa);
            GeneraChiave(chiaveVerde, posVerde);
            GeneraChiave(chiaveBlu, posBlu);
            b_chiaviUffCameretta = true;
        }
    }

    private void GeneraChiave(GameObject chiave,Transform[] posizioni)
    {
        //seleziona la posizione randomica dove spawnare la chiave
        sceltaPosizione = Random.Range(0, posizioni.Length);
        Instantiate(chiave, posizioni[sceltaPosizione], false);
    }

 
}
