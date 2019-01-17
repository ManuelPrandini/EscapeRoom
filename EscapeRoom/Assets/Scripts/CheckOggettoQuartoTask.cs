using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOggettoQuartoTask : MonoBehaviour {

    public string nomeOggetto;
    public static bool b_sapone, b_phon, b_spazzola = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == nomeOggetto)
        {
            switch(nomeOggetto)
            {
                case "sapone" : b_sapone = true;break;
                case "phon": b_phon = true;break;
                case "spazzola": b_spazzola = true; break;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == nomeOggetto)
        {
            switch (nomeOggetto)
            {
                case "sapone": b_sapone = false; break;
                case "phon": b_phon = false; break;
                case "spazzola": b_spazzola = false; break;
            }
        }
    }
}
