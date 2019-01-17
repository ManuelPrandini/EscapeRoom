using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondoTask : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if (Gameplay.piatti == 0 &&
            Gameplay.forchette == 0 &&
            Gameplay.coltelli == 0 &&
            Gameplay.cucchiai == 0 &&
            Gameplay.bicchiere && Gameplay.secondoTask)
        {
            Gameplay.secondoTask = false;
            Gameplay.inizioTerzoTask = true;
            GameObject.Find("CucinaController").SetActive(false);
            TestoGioco.playTesto = true;
            
        }
           
	}

    private void OnTriggerEnter(Collider other)
    {
        //condizioni per i Piatti
        if((other.name == "piatto" || other.name == "piatto1"
            || other.name == "piatto2" || other.name == "piatto3"))
        {
            Gameplay.piatti--;
        }

        //condizioni per le forchette
        if ((other.name == "forchetta" || other.name == "forchetta1"
            || other.name == "forchetta2" || other.name == "forchetta3"))
        {
            Gameplay.forchette--;
        }

        //condizioni per i coltelli
        if ((other.name == "coltello" || other.name == "coltello1"
            || other.name == "coltello2" || other.name == "coltello3"))
        {
            Gameplay.coltelli--;
        }

        //condizioni per i cucchiai
        if ((other.name == "cucchiaio" || other.name == "cucchiaio1"
            || other.name == "cucchiaio2" || other.name == "cucchiaio3"))
        {
            Gameplay.cucchiai--;
        }

        if(other.name == Gameplay.tipoBicchiere)
        {
            Gameplay.bicchiere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //condizioni per i Piatti
        if ((other.name == "piatto" || other.name == "piatto1"
            || other.name == "piatto2" || other.name == "piatto3"))
        {
            Gameplay.piatti++;
        }

        //condizioni per le forchette
        if ((other.name == "forchetta" || other.name == "forchetta1"
            || other.name == "forchetta2" || other.name == "forchetta3"))
        {
            Gameplay.forchette++;

        }

        //condizioni per i coltelli
        if ((other.name == "coltello" || other.name == "coltello1"
            || other.name == "coltello2" || other.name == "coltello3"))
        {
            Gameplay.coltelli++;

        }

        //condizioni per i cucchiai
        if ((other.name == "cucchiaio" || other.name == "cucchiaio1"
            || other.name == "cucchiaio2" || other.name == "cucchiaio3"))
        {
            Gameplay.cucchiai++;

        }

        if (other.name == Gameplay.tipoBicchiere)
        {
            Gameplay.bicchiere = false;
        }
    }
}
