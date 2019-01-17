using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnaSedie : MonoBehaviour {

    public GameObject sediaSalone;
    public Transform[] posSedieSalone;
    public static int sceltaSedieSalone;

    public GameObject sgabello;
    public Transform[] posSgabelli;
    public static int sceltaSgabelli;

    public GameObject sediaCucina;
    public Transform[] posSedieCucina;
    public static int sceltaSedieCucina;

    // Use this for initialization
    void Awake () {
        //spawn delle sedie del salone
        sceltaSedieSalone = Random.Range(0, 7);
        for(int i = 0;i<sceltaSedieSalone;i++)
        {
            Instantiate(sediaSalone, posSedieSalone[i], false);
        }
        

        //spawn dei sgabelli esterni
        sceltaSgabelli = Random.Range(0, 9);
        for (int i = 0; i < sceltaSgabelli; i++)
        {
            Instantiate(sgabello, posSgabelli[i], false);
        }

        //spawn delle sedie della cucina
        sceltaSedieCucina = Random.Range(0, 6);
        for (int i = 0; i < sceltaSedieCucina; i++)
        {
            Instantiate(sediaCucina, posSedieCucina[i], false);
        }
    }
	
}
