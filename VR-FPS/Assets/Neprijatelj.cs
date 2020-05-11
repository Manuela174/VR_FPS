using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neprijatelj : MonoBehaviour {

    public float brzina = 1f;
    public Vector3 direction;
    //Use this for initialization
    void Start ()
    {

    }

	
	// Update is called once per frame
	void Update () {
        transform.position += direction * brzina * Time.deltaTime;
		
	}
}
