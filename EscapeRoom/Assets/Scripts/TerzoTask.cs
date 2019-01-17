using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerzoTask : MonoBehaviour {

    public GameObject vaso;
    public GameObject pianta;

    public Transform[] posizioneVaso;
    public Transform[] posizionePianta;
    public Transform posOggettoSpostato;
    private int sceltaVaso;
    private int sceltaPianta;
    private int scegliOggetto;
    public static bool oggettoSpostato = false;

    // Use this for initialization
    void Start () {
        //seleziona la posizione randomica dove spawnare gli oggetti
        sceltaVaso = Random.Range(0, posizioneVaso.Length);
        Instantiate(vaso, posizioneVaso[sceltaVaso], false);

        sceltaPianta = Random.Range(0, posizionePianta.Length);
        Instantiate(pianta, posizionePianta[sceltaPianta], false);
    }
	
	// Update is called once per frame
	void Update () {
		if(Gameplay.terzoTask && !oggettoSpostato)
        {
            scegliOggetto = Random.Range(0, 2);
            switch(scegliOggetto)
            {
                case 0:
                    {
                        SpostaOggetto(vaso, posizioneVaso, sceltaVaso);
                        break;
                    }
                case 1:
                    {
                        SpostaOggetto(pianta, posizionePianta, sceltaPianta);
                        break;
                    }
            }


            oggettoSpostato = true;
        }
	}


    //procedura da chiamare all'interno dello switch
    private void SpostaOggetto(GameObject oggetto,Transform[] posizioni,int scelta)
    {
        Destroy(posizioni[scelta].GetChild(0).gameObject);
        Instantiate(oggetto, posOggettoSpostato, false);
        for (int i = 0; i < posizioni.Length; i++)
        {
            if (i == scelta) continue;
            posizioni[i].gameObject.SetActive(false);
        }
    }
}
