using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class gestionePorte : MonoBehaviour {

    public float speed = 3f;
    private Transform padre;
    private Transform tipoPorta;
    private int verso = -1; //indica se spingere o tirare
    private Vector3 direzione; // indica il versore del vettore
    private float asseMouse;
    public static bool chiaveCamera = false;
    public static bool chiaveBagni = false;
    public static bool chiaveCameretta = false;
    public static bool chiaveUfficio = false;
    public static bool chiaveFinale = false;

    public static string nomeChiaveUfficio;
    public static string nomeChiaveCameretta;
    private int[] sceltaChiavi;

    // Use this for initialization
    void Start () {
        padre = transform.parent;
        tipoPorta = padre.parent;
        direzione = Vector3.forward;

        //scegli chiavi per cameretta e ufficio
        sceltaChiavi = sceltaChiaviCamerettaUfficio();
        //scelta per l'ufficio
        switch(sceltaChiavi[0])
        {
            case 0: nomeChiaveUfficio = "chiaveRossa(Clone)";break;
            case 1: nomeChiaveUfficio = "chiaveVerde(Clone)"; break;
            case 2: nomeChiaveUfficio = "chiaveBlu(Clone)"; break;
        }
        //scelta per la cameretta
        switch (sceltaChiavi[1])
        {
            case 0: nomeChiaveCameretta = "chiaveRossa(Clone)"; break;
            case 1: nomeChiaveCameretta = "chiaveVerde(Clone)"; break;
            case 2: nomeChiaveCameretta = "chiaveBlu(Clone)"; break;
        }
    }
	


    private void OnMouseDrag()
    {

        //setto la variabile statica per indicare che la rotazione
        //della camera deve fermarsi
        FirstPersonController.cameraIsLocked = true;

        //correzione di variabili --> se interagisco con la maniglia interna
        //tiro la porta a me se sto muovendo il mouse verso il basso.
        verso = (transform.name == "manigliaInterna") ? -1 : 1;
        asseMouse = Input.GetAxis("Mouse Y");

        //controlli limiti --> per la portaBagno è diverso poichè si apre nel verso opposto
        if(tipoPorta.name == "portaBagno")
        {
            
            if (padre.transform.localRotation.z > -0.7071068f)
                padre.transform.localRotation = new Quaternion(padre.transform.localRotation.x, padre.transform.localRotation.y, -0.7071068f, padre.transform.localRotation.w);
            if (padre.localRotation.z < -0.99f)
                padre.localRotation = new Quaternion(padre.localRotation.x, padre.localRotation.y, -0.99f, padre.localRotation.w);
                    
        }
        else if (padre.transform.localRotation.z < -0.7071068f)
                padre.transform.localRotation = new Quaternion(padre.transform.localRotation.x, padre.transform.localRotation.y, -0.7071068f, padre.transform.localRotation.w);
        else if (padre.transform.localRotation.z > -0.025f)
                padre.transform.localRotation = new Quaternion(padre.transform.localRotation.x, padre.transform.localRotation.y, -0.025f, padre.transform.localRotation.w);
        
        
        //movimento delle porte sbloccate
        if(chiaveCamera && tipoPorta.name == "portaCamera")
            padre.Rotate((verso * direzione) * (asseMouse * 10), speed * 10 * Time.deltaTime);

        if (chiaveBagni && (tipoPorta.name == "portaBagno" || tipoPorta.name == "portaBagno2"))
            padre.Rotate((verso * direzione) * (asseMouse * 10), speed * 10 * Time.deltaTime);

        if (chiaveUfficio && chiaveCameretta && (tipoPorta.name == "portaUfficio" || tipoPorta.name == "portaCameretta"))
            padre.Rotate((verso * direzione) * (asseMouse * 10), speed * 10 * Time.deltaTime);

        
    }

    private void OnMouseUp()
    {
        FirstPersonController.cameraIsLocked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //controlla se le varie chiavi sono state inserite nelle porte corrette
        if (other.name == "chiaveCamera(Clone)" && tipoPorta.name=="portaCamera")
        {
            chiaveCamera = true;
            Gameplay.primoTask = false;
            Gameplay.inizioSecondoTask = true;
            TestoGioco.playTesto = true;
            Destroy(other.gameObject);
        }
        if(other.name == "chiaveBagni(Clone)" && (tipoPorta.name == "portaBagno" || tipoPorta.name == "portaBagno2"))
        {
            chiaveBagni = true;
            Gameplay.inizioQuartoTask = false;
            Gameplay.quartoTask = true;
            TestoGioco.playTesto = true;
            Destroy(other.gameObject);
        }

        if(other.name == nomeChiaveCameretta && tipoPorta.name == "portaCameretta")
        {
            chiaveCameretta = true;
            if(chiaveUfficio)
            {
                Gameplay.inizioQuintoTask = false;
                Gameplay.quintoTask = true;
            }
            TestoGioco.playTesto = true;
            Destroy(other.gameObject);
        }

        if (other.name == nomeChiaveUfficio && tipoPorta.name == "portaUfficio")
        {
            chiaveUfficio = true;
            if (chiaveCameretta)
            {
                Gameplay.inizioQuintoTask = false;
                Gameplay.quintoTask = true;
            }
            TestoGioco.playTesto = true;
            Destroy(other.gameObject);
        }

        //Gioco finito
        if(other.name == "chiaveFinale" && tipoPorta.name == "portaPrincipale")
        {
            chiaveFinale = true;
            Gameplay.sestoTask = false;
            Gameplay.fineGioco = true;
            Destroy(other.gameObject);
        }

    }


    //valori[0] indica ufficio , valori[1] la cameretta
    private int[] sceltaChiaviCamerettaUfficio()
    {
        int[] valori = new int[2];
        valori[0] = Random.Range(0, 3);
        valori[1] = Random.Range(0, 3);
        if (valori[0] == valori[1]) valori[1]+=1%3;
        return valori;
    }
}
