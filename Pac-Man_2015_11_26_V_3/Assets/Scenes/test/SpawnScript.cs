using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject pacMan;
    public GameObject ball;
    public GameObject map;
    public GameObject fruit;
    public GameObject pill;
    public GameObject ghostP;
    public GameObject ghostC;
    public GameObject ghostI;
    public GameObject ghostB;
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
        
        fruitBool = true;
        
    }

    //Spawnar frukt
    void spawnfruit(Vector3 fruitVector)
    {
        Instantiate(fruit, fruitVector, Quaternion.identity);
    }

    //Spawnar piller
    void spawnPill(Vector3 pillVector)
    {
        Instantiate(pill, pillVector, Quaternion.identity);
    }

    
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
                fruitTimer = 0;            
			}
        }

     


    }

}
