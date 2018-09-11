using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelterUpdate : MonoBehaviour {

    public int tipo;
     
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject go = Findgg();
        // actualizacion de la currency
        Gamegod gg = go.GetComponent<Gamegod>();

        if(tipo == 1)
        {
            GetComponent<Text>().text = " " + gg.s1 + "";
        }
        if (tipo == 2)
        {
            GetComponent<Text>().text = " " + gg.s2 + "";
        }
        if (tipo == 3)
        {
            GetComponent<Text>().text = " " + gg.s3 + "";
        }
        if (tipo == 4)
        {
            GetComponent<Text>().text = "Hazard: " + gg.hdestroy + "";
        }
        

    }
    private GameObject Findgg()
    {
        GameObject go = GameObject.Find("Gamegod");
        return go;
    }
}
