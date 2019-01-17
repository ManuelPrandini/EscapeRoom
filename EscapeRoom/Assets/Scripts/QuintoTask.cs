using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuintoTask : MonoBehaviour {

    private int sceltaGioco;
    public static bool pariDispari = false;
    public static bool minoreMaggiore = false;
    public static int sceltaLimite = 0;
    public static int minori;
    public static int maggiori;
    public static int pari = 4;
    public static int dispari = 5;

	// Use this for initialization
	void Start () {

        //scegli il gioco da fare in cameretta
        sceltaGioco = Random.Range(0, 2);
        if (sceltaGioco == 0) pariDispari = true;
        else if (sceltaGioco == 1)
        {
            
            minoreMaggiore = true;
            //scegli il limite dei maggiori e dei minori(nei minori è compreso anche il limite, quindi <=)
            sceltaLimite = Random.Range(1, 10);
            print("minoreMaggiore di " + sceltaLimite);
            minori = sceltaLimite;
            maggiori = 9 - sceltaLimite;
        }

	}
	
	// Update is called once per frame
	void Update () {

        //condizioni di vittoria quinto task
		if(Gameplay.quintoTask && pariDispari)
        {
            if(pari == 0 && dispari == 0)
            {
                Gameplay.quintoTask = false;
                Gameplay.sestoTask = true;
                TestoGioco.playTesto = true;
            }
        }
        else if(Gameplay.quintoTask && minoreMaggiore)
        {
            if(minori == 0 && maggiori == 0)
            {
                Gameplay.quintoTask = false;
                Gameplay.sestoTask = true;
                TestoGioco.playTesto = true;
            }
        }
	}

}
