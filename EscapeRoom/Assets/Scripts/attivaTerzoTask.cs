using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attivaTerzoTask : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !Gameplay.terzoTask)
        {
            Gameplay.inizioTerzoTask = false;
            Gameplay.terzoTask = true;
            TestoGioco.playTesto = true;
        }
    }
}
