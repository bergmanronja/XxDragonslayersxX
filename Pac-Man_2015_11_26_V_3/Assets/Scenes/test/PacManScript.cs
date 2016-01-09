using UnityEngine;
using System.Collections;


public class PacManScript : MonoBehaviour {

    float speed = 3.0f;
    public static bool eat = false;
    float timer;
    bool hit;
    GameObject cross;
    AudioClip skull;

	//int run = 1;
	public Animator pmanitest;

    void Start()
    {

		pmanitest = GetComponent<Animator> ();
		pmanitest.Play ("Idle");

        cross = GameObject.Find("CrossPac");
//        cross.SetActive(false);
        skull = (AudioClip)Resources.Load("Skull", typeof(AudioClip));
    }

    void OnCollisionEnter(Collision other)
    {
        //PackMan kolliderar med en ball
        if (other.gameObject.tag == "Ball")
        {

            Destroy(other.gameObject);
            PointsScript.points.Points(1);
        }

        //PackMan kolliderar med en frukt
        if (other.gameObject.tag == "Fruit")
        {
            Destroy(other.gameObject);
            PointsScript.points.Points(10);
            SpawnScript.spawn.fruitBool = true;
        }

        //PackMan kolliderar med ett piller
        if (other.gameObject.tag == "Weapon")
        {
            Destroy(other.gameObject);
            eat = true;
            Debug.Log(eat);
            cross.SetActive(true);
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Ghost"))
            {
              
                    //g.GetComponent<Ghost>().Flee();
            }
            


        }

        //PackMan kolliderar med ett spöke 
        if (other.gameObject.tag == "Ghost")
        {
            if (eat == false)
            {
                hit = true;
                
            }
            else
            {
                //Destroy(other.gameObject);
                PointsScript.points.Points(30);

            }

        }

        //PackMan kolliderar med en teleport
        if (other.gameObject.name == "Teleport1")
        {
            transform.position = new Vector3(-11, -0.5f, -9);
        }

        if (other.gameObject.name == "Teleport2")
        {
            transform.position = new Vector3(-11, -0.5f, 9);
        }



    }

    void Move() //PacMans rörelse förmågor
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
			pmanitest.SetInteger ("run", 1);
			//pmanitest.Play ("Running");
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(GetComponent<Rigidbody>().position, Vector3.down, 180 * Time.deltaTime);
			pmanitest.SetInteger ("run", 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(GetComponent<Rigidbody>().position, Vector3.up, 180 * Time.deltaTime);
			pmanitest.SetInteger ("run", 1);
        }

		if (Input.GetKeyDown (KeyCode.S)) {
			transform.RotateAround (GetComponent<Rigidbody> ().position, Vector3.up, 180);
			pmanitest.SetInteger ("run", 1);
		} 
		else {
			pmanitest.SetInteger ("run", 0);
		}
    }

        void Update()
    {
        //Om PacMan har tagit upp ett piller ska han istället för att bli dödad av spöken äta dem under en viss tid.
        if (eat == true)
        {
            timer += Time.deltaTime;

            if (timer >= ScoreScript.score.ghostFleeTimer)
            {
                eat = false;
                cross.SetActive(false);
                timer = 0;
            }
        }
        
        if (hit)
        {
            PointsScript.points.Damage();
            GetComponent<Rigidbody>().position = new Vector3(-11, -0.5f, -8);
            hit = false;    
        }

        else
        {
            Move();
        }
    }
}