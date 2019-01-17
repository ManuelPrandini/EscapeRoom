using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremiTasto : MonoBehaviour {

    public AudioClip tastoPremuto;

    private void OnMouseDown()
    {
        Gameplay.inputCassaforte += this.name.Remove(0,5);
        this.transform.parent.gameObject.GetComponent<AudioSource>().PlayOneShot(tastoPremuto);
    }

    

    

}
