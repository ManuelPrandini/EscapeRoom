using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPariMinori : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
            //se è attivo il gioco pariDispari e se il numero del libro è pari
            if(other.tag == "libro" && QuintoTask.pariDispari && (Char.GetNumericValue(other.name.ToCharArray()[other.name.Length-1]) % 2 == 0 ))
            {
                QuintoTask.pari--;
            }

            if(other.tag == "libro" && QuintoTask.minoreMaggiore && (Char.GetNumericValue(other.name.ToCharArray()[other.name.Length - 1]) <= QuintoTask.sceltaLimite))
            {
                QuintoTask.minori--;
            }
    }

    private void OnTriggerExit(Collider other)
    {
            //se è attivo il gioco pariDispari e se il numero del libro è pari
            if (other.tag == "libro" && QuintoTask.pariDispari && (Char.GetNumericValue(other.name.ToCharArray()[other.name.Length - 1]) % 2 == 0))
            {
                QuintoTask.pari++;
            }
        
            if (other.tag == "libro" && QuintoTask.minoreMaggiore &&(Char.GetNumericValue(other.name.ToCharArray()[other.name.Length - 1]) <= QuintoTask.sceltaLimite))
            {
                QuintoTask.minori++;
            }
    }
}
