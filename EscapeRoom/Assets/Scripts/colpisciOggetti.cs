using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colpisciOggetti : MonoBehaviour {

    public float distanzaRaggio;
    public int speed;
    private bool click = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanzaRaggio) && hit.transform.tag == "maniglia")
        {
            if(!click)
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("selezionato la "+hit.transform.name+ " che apre "+hit.transform.parent.name);

            if (Input.GetMouseButtonDown(0))
            {
                click = true;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            }
            //clicco e tengo premuto
            if (Input.GetMouseButton(0))
            {
                hit.transform.parent.Rotate(-Vector3.forward * (Input.GetAxis("Mouse Y") * 10), speed * 10 * Time.deltaTime);
            }
            
        }

    }
}
