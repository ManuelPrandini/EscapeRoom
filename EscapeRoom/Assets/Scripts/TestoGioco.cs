using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestoGioco : MonoBehaviour {

    public string[] primoTask;
    public string[] inizioSecondoTask;
    private string[] secondoTask;
    public string[] inizioTerzoTask;
    private string[] terzoTask;
    public string[] inizioQuartoTask;
    private string[] quartoTask;
    private string[] inizioQuintoTask;
    private string[] quintoTask;
    private string[] SestoTask;
    private string[] inEsecuzione;
    private string riga = "";
    public float ritardo = 0.1f;
    public static bool playTesto;

	// Use this for initialization
	void Start () {
        playTesto = true;
    }

    private void Update()
    {

        //Suggerimenti per rileggere testo
        if (Input.GetKey(KeyCode.H))
            StartCoroutine(AnimazioneTesto(inEsecuzione));

        //se la variabile booleana è attiva , seleziona l'array di testo da
        //mandare in esecuzione, lo passa come parametro all'IENumerator
        //e attraverso StartCoroutine() si avvia l'output su schermo.
        if (playTesto)
        {
            if (Gameplay.primoTask)
                inEsecuzione = primoTask;
            else if (Gameplay.inizioSecondoTask)
                inEsecuzione = inizioSecondoTask;
            else if (Gameplay.secondoTask)
            { 
                inEsecuzione = GeneraSecondoTask(Gameplay.piatti, Gameplay.forchette, Gameplay.coltelli, Gameplay.cucchiai);
                ritardo = 0.2f;
            }
            else if (Gameplay.inizioTerzoTask)
                inEsecuzione = inizioTerzoTask;
            else if (Gameplay.terzoTask)
                inEsecuzione = GeneraTerzoTask();
            else if (Gameplay.inizioQuartoTask)
                inEsecuzione = inizioQuartoTask;
            else if (Gameplay.quartoTask)
                inEsecuzione = GeneraQuartoTask();
            else if (Gameplay.inizioQuintoTask)
            {
                //se ho trovato una delle due chiavi e l'ho inserita nella porta giusta
                if (gestionePorte.chiaveCameretta || gestionePorte.chiaveUfficio)
                {
                    inEsecuzione[0] = "Bene! Ne manca ancora 1";
                    playTesto = false;
                }
                else
                {
                    inizioQuintoTask = GeneraInizioQuintoTask(gestionePorte.nomeChiaveUfficio, gestionePorte.nomeChiaveCameretta);
                    inEsecuzione = inizioQuintoTask;
                }
            }
            else if (Gameplay.quintoTask)
                inEsecuzione = GeneraQuintoTask(QuintoTask.pariDispari, QuintoTask.sceltaLimite);
            else if (Gameplay.sestoTask)
                inEsecuzione = GeneraSestoTask();
            else if (Gameplay.fineTask)
                inEsecuzione = GeneraFineTask();

            StartCoroutine(AnimazioneTesto(inEsecuzione));
            playTesto = false;
        }
    }


    private string[] GeneraSecondoTask(int piatti,int forchette,int coltelli, int cucchiai)
    {
        string[] testo = new string[6];
        testo[0] = "Apparecchia il tavolo secondo queste direttive:";
        testo[1] = "Prendi " + piatti + " piatti";
        testo[2] = "Prendi " + forchette + " forchette";
        testo[3] = "Prendi " + coltelli + " coltelli";
        testo[4] = "Prendi " + cucchiai + " cucchiai";
        testo[5] = "Del bicchiere , prendi quello " + Gameplay.tipoBicchiere;
        return testo;
    }

    private string[] GeneraTerzoTask()
    {
        string[] testo = new string[3];
        testo[0] = "E' comparso un oggetto sul tavolo del Salone";
        testo[1] = "Ricordi dove era posizionato?";
        testo[2] = "Rimettilo al suo posto originale";
        return testo;
    }

    private string[] GeneraQuartoTask()
    {
        string[] testo = new string[4];
        testo[0] = "Questa chiave sblocca i due bagni";
        testo[1] = "Nel bagno più grande hai degli oggetti";
        testo[2] = "Trasferiscili nel bagno più piccolo";
        testo[3] = "Rispetta le posizioni";
        return testo;
    }

    private string[] GeneraInizioQuintoTask(string ufficio,string cameretta)
    {
        //Quando si usa il metodo remove si intende la rimozione della stringa "(Clone)"
        string[] testo = new string[4];
        testo[0] = "Bene! Ora manca di sbloccare le porte dell'Ufficio e della Cameretta";
        testo[1] = "Per l'Ufficio trova la "+ufficio.Remove(ufficio.Length-7);
        testo[2] = "Per la Cameretta trova la "+cameretta.Remove(cameretta.Length-7);
        return testo;
    }

    private string[] GeneraQuintoTask(bool pariDispari,int limite)
    {
        string[] testo = new string[3];
        testo[0] = "Perfetto! E' il tuo penultimo esercizio";
        testo[1] = "Entra in cameretta e metti i libri numerati da 1 a 9 nel seguente modo :";
        testo[2] = (pariDispari ? "Metti i pari nel ripiano centrale della libreria e i dispari nel ripiano più alto" :
            "Metti i minori e uguali a "+limite+ " nel ripiano centrale della libreria e i maggiori di "+limite+ " nel ripiano più alto");
        
        return testo;
    }

    private string[] GeneraSestoTask()
    {
        string[] testo = new string[5];
        testo[0] = "Bene ! Per l'ultimo esercizio vai in Ufficio";
        testo[1] = "Nella cassaforte che troverai, inserisci il codice formato da : ";
        testo[2] = "La somma delle sedie della cucina con quelle del salone e con i sgabelli all'esterno;";
        testo[3] = "La differenza tra le sedie del salone e i sgabelli all'esterno;";
        testo[4] = "La metà della somma delle gambe di tutte le sedie del salone,della cucina,e dei sgabelli all'esterno ;";
        return testo;
    }

    private string[] GeneraFineTask()
    {
        string[] testo = new string[2];
        testo[0] = "Complimenti ! Hai trovato la chiave finale";
        testo[1] = "Ora esci dalla casa per terminare l'esercitazione!";
        return testo;
    }


        public IEnumerator AnimazioneTesto(string[] testo)
    {
        for (int i = 0; i <testo.Length; i++)
        {
            for (int j = 0; j <= testo[i].Length; j++)
            {
                riga = testo[i].Substring(0, j);
                this.GetComponent<Text>().text = riga;
                yield return new WaitForSeconds(ritardo);
            }
            yield return new WaitForSeconds(ritardo+0.3f);
            this.GetComponent<Text>().text = "";
        }
    }

}
