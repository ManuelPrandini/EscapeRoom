using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDispariMaggiori : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
            //se è attivo il gioco pariDispari e se il numero del libro è dispari
            if (other.tag == "libro" && QuintoTask.pariDispari && (Char.GetNumericValue(other.name.ToCharArray()[other.name.Length - 1]) % 2 == 1))
            {
                QuintoTask.dispari--;
            } 

            if (other.tag == "libro" && QuintoTask.minoreMaggiore && (Char.GetNumericValue(other.name.ToCharArray()[other.name.Length - 1]) > QuintoTask.sceltaLimite))
            {
            
                QuintoTask.maggiori--;
            }
    }

    private void OnTriggerExit(Collider other)
    {
            //se è attivo il gioco pariDispari e se il numero del libro è pari
            if (other.tag == "libro" && QuintoTask.pariDispari && (Char.GetNumericValue(other.name.ToCharArray()[other.name.Length - 1]) % 2 == 1))
            {
                QuintoTask.dispari++;
            }

           if (other.tag == "libro" && QuintoTask.minoreMaggiore && (Char.GetNumericValue(other.name.ToCharArray()[other.name.Length - 1]) > QuintoTask.sceltaLimite))
            {
                QuintoTask.maggiori++;
            }
    }
}
