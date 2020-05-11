using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Camera gameCamera;
    public GameObject metakPrefab;
    public GameObject neprijateljPrefab;
    private float vrijemePucanja = 0;
    private float vrijemeMirovanjaPucanja = 0;
    private float NeprijateljSpawningTimer = 0;
    public float NeprijateljSpawingMirovanje = 1f;
    public float NeprijateljSpawningDistance = 7f;

    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Neprijatelj")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    // Update is called once per frame
    void Update()
    {
        vrijemePucanja -= Time.deltaTime;
        NeprijateljSpawningTimer -= Time.deltaTime;

        if (NeprijateljSpawningTimer <= 0f)
        {
            NeprijateljSpawningTimer = NeprijateljSpawingMirovanje;

            GameObject enemyObject = Instantiate(neprijateljPrefab);

            float randomAngine = Random.Range(0, Mathf.PI * 2);
            enemyObject.transform.position = new Vector3(gameCamera.transform.position.x + Mathf.Cos(randomAngine) * NeprijateljSpawningDistance, 0,
                gameCamera.transform.position.z + Mathf.Sin(randomAngine) * NeprijateljSpawningDistance);

            Neprijatelj neprijatelj = enemyObject.GetComponent<Neprijatelj>();
            neprijatelj.direction = (gameCamera.transform.position - neprijatelj.transform.position).normalized;
            neprijatelj.transform.LookAt(Vector3.zero);
        }

        RaycastHit hit;

        if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Neprijatelj" && vrijemePucanja <= 0f)
            {
                vrijemePucanja = vrijemeMirovanjaPucanja = 0;

                GameObject metakObject = Instantiate(metakPrefab);
                metakObject.transform.position = gameCamera.transform.position;

                Metak metak = metakObject.GetComponent<Metak>();
                metak.direction = gameCamera.transform.forward;

            }
        }
    }
}
