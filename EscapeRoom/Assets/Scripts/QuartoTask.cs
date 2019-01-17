using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuartoTask : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
		if(CheckOggettoQuartoTask.b_phon && CheckOggettoQuartoTask.b_sapone
            && CheckOggettoQuartoTask.b_spazzola && Gameplay.quartoTask)
        {
            Gameplay.quartoTask = false;
            Gameplay.inizioQuintoTask = true;
            TestoGioco.playTesto = true;
        }
	}
}
