using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour {

    //controlli di attivazione task
    public static bool primoTask = true;
    public static bool inizioSecondoTask = false;
    public static bool secondoTask = false;
    public static bool inizioTerzoTask = false;
    public static bool terzoTask = false;
    public static bool inizioQuartoTask = false;
    public static bool quartoTask = false;
    public static bool inizioQuintoTask = false;
    public static bool quintoTask = false;
    public static bool sestoTask = false;
    public static bool fineTask = false;
    public static bool fineGioco = false;

    //controlli del Task della cucina
    public static int piatti;
    public static int coltelli;
    public static int forchette;
    public static int cucchiai;
    public static bool bicchiere = false;
    public static string tipoBicchiere;
    private int sceltaBicchiere;


    //controlli dell'Ultimo Task relativo alla cassaforte
    public static string codiceFinale;
    public static string inputCassaforte = "";
    public Transform maniglia;
    public Transform rotazioneManiglia;
    public Transform sportelloCassaforte;
    public Transform posFinaleSportelloCassaforte;
    public Text testoCassaforte;


    private void Start()
    {
        //Del task due scegli quanti oggetti prendere
        coltelli = Random.Range(1, 5);
        forchette = Random.Range(1, 5);
        cucchiai = Random.Range(1, 5);
        piatti = Random.Range(1, 5);
        sceltaBicchiere = Random.Range(1, 6);

        switch(sceltaBicchiere)
        {
            case 1 : tipoBicchiere = "piùPiccolo";break;
            case 2: tipoBicchiere = "traIntermedioEPiccolo"; break;
            case 3: tipoBicchiere = "intermedio"; break;
            case 4: tipoBicchiere = "traIntermedioEGrande"; break;
            case 5: tipoBicchiere = "piùGrande"; break;
        }

        //genera il codice della cassaforte
        codiceFinale = (spawnaSedie.sceltaSedieCucina + spawnaSedie.sceltaSedieSalone + spawnaSedie.sceltaSgabelli) +""+
            Mathf.Abs(spawnaSedie.sceltaSgabelli-spawnaSedie.sceltaSedieSalone) + ""+
            ((spawnaSedie.sceltaSedieCucina + spawnaSedie.sceltaSedieSalone + spawnaSedie.sceltaSgabelli)*2);
        
        print("codiceFinale-->" + codiceFinale);
    }

    private void FixedUpdate()
    {
        if (inputCassaforte == codiceFinale && sestoTask)
        {
            testoCassaforte.color = Color.green;
            apriCassaforte();
            sestoTask = false;
            fineTask = true;
            TestoGioco.playTesto = true;
        }
        if (inputCassaforte.Length > codiceFinale.Length)
        {
            inputCassaforte = "";
        }
        testoCassaforte.text = inputCassaforte;

        //se è finito il gioco
        if (fineGioco)
        {
            print("fineGioco");
            fineGioco = false;
            GameObject.Find("Player").gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false ;
            GameObject.Find("FineGioco").SetActive(true);
        }
    }

    private void apriCassaforte()
    {
        maniglia.rotation = new Quaternion(maniglia.transform.rotation.x,
                            maniglia.transform.rotation.x,
                            rotazioneManiglia.transform.rotation.z,maniglia.rotation.w);
        StartCoroutine(apriSportelloCassaforte());
    }
    private IEnumerator apriSportelloCassaforte()
    {
        yield return new WaitForSeconds(1);
        sportelloCassaforte.rotation = new Quaternion(sportelloCassaforte.transform.rotation.x,
        posFinaleSportelloCassaforte.transform.rotation.y,
        sportelloCassaforte.transform.rotation.z,sportelloCassaforte.transform.rotation.w);
        Destroy(testoCassaforte);

    }



}
