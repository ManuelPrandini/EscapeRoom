using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attivaSecondoTask : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !Gameplay.secondoTask)
        {
            Gameplay.inizioSecondoTask = false;
            Gameplay.secondoTask = true;
            TestoGioco.playTesto = true;
        }
    }
}
