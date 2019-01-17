using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selezioneOggetto : MonoBehaviour {

    private Material mat;
    private Color coloreOriginalePadre;
    private Color[] coloriOriginaliFigli;
    private Color coloreSelezione = Color.yellow;
    private Material[] children;
    // Use this for initialization
    void Start () {
        mat = GetComponent<Renderer>().material;
        coloreOriginalePadre = mat.color;
        children = new Material[this.transform.GetChildCount()];
        coloriOriginaliFigli = new Color[this.transform.GetChildCount()];
        for(int i = 0;i < this.transform.GetChildCount();i++)
        {
            children[i] = this.transform.GetChild(i).gameObject.GetComponent<Renderer>().material;
            coloriOriginaliFigli[i] = children[i].color;
        }
    }
	
	
    private void OnMouseDrag()
    {
        //rendi oggetto selezionato
        mat.color = coloreSelezione;
        for (int i = 0; i < this.transform.GetChildCount(); i++)
        {
            children[i].color = coloreSelezione ;
        }

    }
    private void OnMouseEnter()
    {
        mat.color = coloreSelezione;
        for (int i = 0; i < this.transform.GetChildCount(); i++)
        {
            children[i].color = coloreSelezione;
        }

    }

    private void OnMouseExit()
    {
        mat.color = coloreOriginalePadre;
        for (int i = 0; i < this.transform.GetChildCount(); i++)
        {
            children[i].color = coloriOriginaliFigli[i];
        }

    }
    private void OnMouseUp()
    {
        mat.color = coloreOriginalePadre;
        for (int i = 0; i < this.transform.GetChildCount(); i++)
        {
            children[i].color = coloriOriginaliFigli[i];
        }

    }
}
