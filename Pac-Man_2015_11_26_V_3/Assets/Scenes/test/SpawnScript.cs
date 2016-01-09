using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

   /* public GameObject pacMan;
    public GameObject ball;
    public GameObject map; */
    public GameObject fruit;
   /* public GameObject pill;
    public GameObject ghostP;
    public GameObject ghostC;
    public GameObject ghostI;
    public GameObject ghostB; */
    public GameObject score;
    public static SpawnScript spawn;
    Vector3[] fruitVector = new Vector3[4];
    Vector3[] ghostVector = new Vector3[4];
    public bool fruitBool;
    public bool pillBool;
    float fruitTimer;
    float pillTimer;

    void Start ()
    {
        spawn = this;
        score = GameObject.Find("ScoreObject");
        DontDestroyOnLoad(score);
       /* //Vectorer för spöken på test bana 
        ghostVector[0] = new Vector3 (-9, -2, -2);
        ghostVector[1] = new Vector3 (-13, -2, 2);
        ghostVector[2] = new Vector3 (-9,-2, 2);
        ghostVector[3] = new Vector3(-12, -2, -2);

        fruitVector[0] = new Vector3(-22, -0.5f, -8);
        fruitVector[1] = new Vector3(-22, -0.5f, 8);
        fruitVector[2] = new Vector3(0, -0.5f, -8);
        fruitVector[3] = new Vector3(0, -0.5f, -8); */


  
        /*spawnMap(map.transform.position);

        spawnInky(ghostVector[0]);
        spawnPinky(ghostVector[1]);
        spawnClyde(ghostVector[2]);
        spawnBlinky(ghostVector[3]); */

        fruitBool = true;
        
    }

   /* //Spawnar PacMan
    public void pacManSpawn(Vector3 pacManVector)
    {
        Instantiate(pacMan, pacManVector, Quaternion.identity);
 
    }

    //Startar en ny bana med bollar och en PacMan.
    void spawnMap(Vector3 mapPosition)
    {
        Instantiate(map, mapPosition, Quaternion.identity);
        pacManSpawn(new Vector3(-11, -0.5f, -8));
        
        
    }
    */
    //Spawnar frukt
    void spawnfruit(Vector3 fruitVector)
    {
        Instantiate(fruit, fruitVector, Quaternion.identity);
    }
    /*
    //Spawnar piller
    void spawnPill(Vector3 pillVector)
    {
        Instantiate(pill, pillVector, Quaternion.identity);
    }

    //Spawnar ett spöke
    void spawnInky(Vector3 ghostVector)
    {
        Instantiate(ghostI, ghostVector, Quaternion.identity);
    }
    void spawnPinky(Vector3 ghostVector)
    {
        Instantiate(ghostP, ghostVector, Quaternion.identity);
    }
    void spawnBlinky(Vector3 ghostVector)
    {
        Instantiate(ghostB, ghostVector, Quaternion.identity);
    }
    void spawnClyde(Vector3 ghostVector)
    {
        Instantiate(ghostC, ghostVector, Quaternion.identity);
    }
    */

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.LoadLevel(0);
        }

        if (fruitBool)
        {
            fruitTimer += Time.deltaTime;
            if(fruitTimer >= 20)
            {
                spawnfruit(fruitVector[Random.Range(0, fruitVector.Length)]);
                fruitTimer = 0;
                fruitBool = false;
            }
        }

        if (fruitBool == false)
        {
            fruitTimer += Time.deltaTime;
            if (fruitTimer >= ScoreScript.score.fruitDestroyTimer)
            {
                Destroy(GameObject.FindWithTag("Fruit"));
                fruitTimer = 0;            }
        }

     


    }

}
