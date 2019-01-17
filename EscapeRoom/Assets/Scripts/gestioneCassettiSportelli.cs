using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class gestioneCassettiSportelli : MonoBehaviour {

    public float speed = 3f;
    private Transform padre;
    private Transform tipoOggetto;
    private int verso = -1; //indica se spingere o tirare
    private Vector3 direzione; // indica il versore del vettore
    private float asseMouse;
   

    private void Start()
    {
        padre = transform.parent;
        tipoOggetto = padre.parent;
    }

    private void OnMouseDrag()
    {
        //setto la variabile statica per indicare che la rotazione
        //della camera deve fermarsi
        FirstPersonController.cameraIsLocked = true;

        //correzione di variabili 
        verso = (padre.name == "sportelloDx" || padre.name == "portaFrigo" || padre.name == "sportello") ?  1 :  -1;
        //condizione per la portaFinestra --> cambia vettore
        if (padre.name == "portaApribile") direzione = Vector3.down;
        else direzione = Vector3.forward;

        //condizione per l'antaScorrevole dell'armadio --> cambia asse e vettore
        if (padre.name == "antaScorrevole")
        {
            direzione = Vector3.up;
            asseMouse = Input.GetAxis("Mouse X");
        }
        //condizione per i cassetti 
        else if (padre.name == "cassettoSuperiore" || padre.name == "cassettoInferiore" || padre.name == "cassetto")
        {
            direzione = Vector3.up;
            asseMouse = Input.GetAxis("Mouse Y");
        }
        //per tutti gli altri oggetti usa l'asse Y
        else asseMouse = Input.GetAxis("Mouse Y");



        //MOVIMENTI
        //se si apre un Armadio , scorri asse X mouse per traslare l'oggetto,
        //altrimenti per sportelli e porte scorri asse Y mouse per ruotare
        if (padre.name == "antaScorrevole")
        {
            //controlli per i limiti
            if (padre.transform.localPosition.y < 0) padre.transform.localPosition = new Vector3(0, 0, 0);
            if (padre.transform.localPosition.y > 0.3f) padre.transform.localPosition = new Vector3(0, 0.3f, 0);

            padre.Translate(direzione.x, direzione.y * (asseMouse * Time.deltaTime), direzione.z);
        }
        else if (padre.name == "cassettoSuperiore" || padre.name == "cassettoInferiore" || padre.name == "cassetto")
        {
            //controlli limiti cassetto 
            if (padre.name == "cassetto")
            {
                if (padre.transform.localPosition.y < -0.2f)
                    padre.transform.localPosition = new Vector3(padre.transform.localPosition.x, -0.2f, padre.transform.localPosition.z);
                if (padre.transform.localPosition.y > 0f)
                    padre.transform.localPosition = new Vector3(padre.transform.localPosition.x, 0f, padre.transform.localPosition.z);
            }
            else if (padre.name == "cassettoSuperiore" || padre.name == "cassettoInferiore")
            {
                //controlli per vari tipi di cassetti dei diversi oggetti
                if (tipoOggetto.name == "comodinoCamera" || tipoOggetto.name == "comodinoCameretta" || tipoOggetto.name == "comodinoCamera2")
                {
                    if (padre.transform.localPosition.y > -0.0157f)
                        padre.transform.localPosition = new Vector3(padre.transform.localPosition.x, -0.0157f, padre.transform.localPosition.z);
                    if (padre.transform.localPosition.y < -0.1005f)
                        padre.transform.localPosition = new Vector3(padre.transform.localPosition.x, -0.1005f, padre.transform.localPosition.z);

                }
                if (tipoOggetto.name == "gruppoMobili")
                {
                    if (padre.transform.localPosition.y > 0.0157f)
                        padre.transform.localPosition = new Vector3(padre.transform.localPosition.x, 0.0157f, padre.transform.localPosition.z);
                    if (padre.transform.localPosition.y < -0.1005f)
                        padre.transform.localPosition = new Vector3(padre.transform.localPosition.x, -0.1005f, padre.transform.localPosition.z);

                }

                if (tipoOggetto.name == "scrivaniaUfficio")
                {
                    if (padre.transform.localPosition.x > -0.1137f)
                        padre.transform.localPosition = new Vector3(-0.1137f, padre.transform.localPosition.y, padre.transform.localPosition.z);
                    if (padre.transform.localPosition.x < -0.183f)
                        padre.transform.localPosition = new Vector3(-0.183f, padre.transform.localPosition.y, padre.transform.localPosition.z);
                }

                if (tipoOggetto.name == "scrivania")
                {
                    if (padre.transform.localPosition.x > -0.203f)
                        padre.transform.localPosition = new Vector3(-0.203f, padre.transform.localPosition.y, padre.transform.localPosition.z);
                    if (padre.transform.localPosition.x < -0.3735f)
                        padre.transform.localPosition = new Vector3(-0.3735f, padre.transform.localPosition.y, padre.transform.localPosition.z);
                }
            }

            padre.Translate(direzione * (asseMouse * Time.deltaTime));
        }
        else if (padre.name == "sportelloSx" || padre.name == "sportelloDx" || padre.name == "sportello"
                || padre.name == "portaFrigo" || padre.name == "portaApribile")
        {
            if(padre.name == "sportelloDx" || padre.name == "portaFrigo" || padre.name == "sportello")
            {
                if(padre.transform.localRotation.z > 0f)
                    padre.transform.localRotation =
                        new Quaternion(padre.transform.localRotation.x, padre.transform.localRotation.y, 0f, padre.transform.localRotation.w);
                if(padre.transform.localRotation.z < -0.65f)
                    padre.transform.localRotation =
                        new Quaternion(padre.transform.localRotation.x, padre.transform.localRotation.y, -0.65f, padre.transform.localRotation.w);
            }
            if(padre.name == "sportelloSx" )
            {
                if(padre.transform.localRotation.z < 0f)
                    padre.transform.localRotation =
                        new Quaternion(padre.transform.localRotation.x, padre.transform.localRotation.y, 0f, padre.transform.localRotation.w);
                if (padre.transform.localRotation.z > 0.65f)
                    padre.transform.localRotation =
                        new Quaternion(padre.transform.localRotation.x, padre.transform.localRotation.y, 0.65f, padre.transform.localRotation.w);
            }
            padre.Rotate((verso * direzione) * (asseMouse * 10), speed * 10 * Time.deltaTime);
        }


    }

    private void OnMouseUp()
    {
        FirstPersonController.cameraIsLocked = false;
    }



}
