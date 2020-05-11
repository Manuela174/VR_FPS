using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metak : MonoBehaviour {

    public float brzina = 1f;
    public Vector3 direction;
    private float zivotnivijek = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += direction * brzina * Time.deltaTime;

        zivotnivijek -= Time.deltaTime;
        if(zivotnivijek <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Neprijatelj")
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
        
    }
}
