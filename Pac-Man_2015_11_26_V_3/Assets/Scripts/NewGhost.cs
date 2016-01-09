using UnityEngine;
using System.Collections;


public class Ghost : MonoBehaviour {


    private GameObject pacMan;
    private NavMeshAgent ghost;
    private float xWanderRange = 16.0f;
    private float zWanderRange = 13.0f;
    public static Vector3 startPosition; 
    private float distanceToAttack = 4.0f;
    private float roamingDelayTimer;
    public Material[] myMats;
    private int index;
    bool flee = true;
    

    void Start () {
        
        startPosition = this.transform.position;
        ghost = GetComponent<NavMeshAgent>();
        pacMan = GameObject.Find("PacManNew(Clone)");

        myMats = new Material[3];

       


        myMats[0] = Resources.Load("Materials/BlinkyC", typeof(Material)) as Material;
        myMats[1] = Resources.Load("BlinkyBlue", typeof(Material)) as Material;
        myMats[2] = Resources.Load("BlinkyDead", typeof(Material)) as Material;

       

        if (gameObject.name == "Clyde CHEW(Clone)")
        {
            roamingDelayTimer = 5.0f;
            myMats[0] = Resources.Load("Materials/ClydeC", typeof(Material)) as Material;
            myMats[1] = Resources.Load("ClydeBlue", typeof(Material)) as Material;
            myMats[2] = Resources.Load("ClydeDead", typeof(Material)) as Material;
        }
        if (gameObject.name == "Pinky CHEW(Clone)")
        {
            roamingDelayTimer = 10.0f;
            myMats[0] = Resources.Load("Materials/PinkyC", typeof(Material)) as Material;
            myMats[1] = Resources.Load("PinkyBlue", typeof(Material)) as Material;
            myMats[2] = Resources.Load("PinkyDead", typeof(Material)) as Material;
        }
        if (gameObject.name == "Inky CHEW(Clone)")
        {
            roamingDelayTimer = 15.0f;
            myMats[0] = Resources.Load("Materials/InkyC", typeof(Material)) as Material;
            myMats[1] = Resources.Load("InkyBlue", typeof(Material)) as Material;
            myMats[2] = Resources.Load("InkyDead", typeof(Material)) as Material;
        }

        ghost.GetComponentInChildren<SkinnedMeshRenderer>().material = myMats[index];
        
 
    }

  
   

    void OnCollisionEnter(Collision other) // När Pacman plockat upp ett kors och kolliderar med ett spöke
    {
        if (PacManScript.eat == true && other.gameObject.tag == "PacMan") 
        {
                flee = false;
                Eaten();
                
        }

       
    }

    void Roaming() //Metod för agenternas vandringsläge. Skapar en instans som tar en agents startkordinat och lägger till en slumpmässig kordinat,
                   //detta resultat används sedan som argument när NewDestination() metoden kallas.
    {
       
        Vector3 destination = startPosition + new Vector3(Random.Range(-xWanderRange, xWanderRange), 0, Random.Range(-zWanderRange, zWanderRange));
        NewDestination(destination);
        
    }

    public void NewDestination(Vector3 nyPos) // Sänder agenten till en punkt i kordinatsystemet.
    {
        ghost.SetDestination(nyPos);
    }

    void startRoaming() //Metod för att starta igång Roaming() metoden. Den säger åt roamingDelayTimer variabeln att räkna ner och så fort den når 0 startar Roaming() metoden.
                        //Sätter även agenternas starthastighet och första utseende index.
    {

        ghost.GetComponent<Collider>().enabled = true;
        flee = true;
        index = 0;
        ghost.speed = 2.0f;
        roamingDelayTimer -= Time.deltaTime;
        if (roamingDelayTimer <= 0)
        {
            Roaming();
            roamingDelayTimer = 5.0f;
        }
    }

  
    void Attack() //Metod för att få agenterna att jaga PacMan
    {
        ghost.SetDestination(pacMan.transform.position);
        ghost.GetComponent<Collider>().enabled = true;

        if (gameObject.name == "Inky CHEW(Clone)")
        {
            ghost.speed = 5.0f;
        }

        if (gameObject.name == "Blinky CHEW(Clone)")
        {
            ghost.speed = 2f;
        }
      
    }

    public void Flee() //Metod för att få agenterna att fly från PacMan, de har varsitt hörn som flyktposition.
    {
              
        if (flee)
        {
            index = 1;
            ghost.SetDestination(new Vector3(-25f, -0.5f, 10f));
           
            if (gameObject.name == "Pinky CHEW(Clone)")
            {
               
                ghost.SetDestination(new Vector3(-25, -0.5f, -10f));
            }

            if (gameObject.name == "Inky CHEW(Clone)")
            {
          
                ghost.SetDestination(new Vector3(2f, -0.5f, -10f));
            }

            if (gameObject.name == "Clyde CHEW(Clone)")
            {
                
                ghost.SetDestination(new Vector3(2f, -0.5f, 10f));
            }
        }
        


    }

    void Eaten() /* Metod för när spökena blir "uppätna" av pacman. Byter färg-index, ökar agentens hastighet,
                   stänger av collidern för att undvika krock med andra agenter samt skickar hem spöket till startpositionen.*/
    {
        

        if (ghost.transform.position != startPosition)
        {
            index = 2;
            ghost.GetComponent<Collider>().enabled = false;
            ghost.speed = 10.0f;
            NewDestination(startPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distFromPac = Vector3.Distance(ghost.transform.position, pacMan.transform.position);

        ghost.GetComponentInChildren<SkinnedMeshRenderer>().material = myMats[index];


        if (PacManScript.eat == false)
        {
            startRoaming();
       
        if (distFromPac <= distanceToAttack)
        {
            Attack();
        }

        if (distFromPac >= distanceToAttack)
        {
            startRoaming();
        }

        

        if (gameObject.name == "Clyde CHEW(Clone)") 
        {
           if (distFromPac <= distanceToAttack)
            {
               
                ghost.SetDestination(new Vector3(2f, -0.5f, 10f));
            }
        }

        if (gameObject.name == "Blinky CHEW(Clone)")
        {
            Attack();
            
        }

        if (gameObject.name == "Inky CHEW(Clone)")
        {
            if (distFromPac <= 2.5f)
            {
                Attack();
            }
        }

        }

       
        
        
    }
}
