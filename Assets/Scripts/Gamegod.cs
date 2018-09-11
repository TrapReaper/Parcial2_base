using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamegod : MonoBehaviour {

    public GameObject shelter1;
    public GameObject shelter2;
    public GameObject shelter3;

    public int s1;
    public int s2;
    public int s3;
    public int hdestroy;

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("Hazards", 0);
        hdestroy = PlayerPrefs.GetInt("Hazards");
    }
	
	// Update is called once per frame
	void Update () {
        s1 = shelter1.GetComponent<Shelter>().GetResistance();
        s2 = shelter2.GetComponent<Shelter>().GetResistance();
        s3 = shelter3.GetComponent<Shelter>().GetResistance();
        hdestroy = PlayerPrefs.GetInt("Hazards");
    }
}
