using UnityEngine;
using System.Collections;


public class NewGhost : MonoBehaviour {


    private GameObject pacMan;
    private NavMeshAgent ghost;
    private float xWRange = 16.0f;
    private float zWRange = 13.0f;
    public static Vector3 startPosition; 
    private float distanceToAttack = 4.0f;
    private float roamingDelayTimer;
    private int index;
    bool flee = true;
    

    void Start () {
        
        startPosition = this.transform.position;
        ghost = GetComponent<NavMeshAgent>();
        pacMan = GameObject.Find("Pacmansnamn");
    }

    void OnCollisionEnter(Collision other) 
	// När Pacman plockat upp ett kors och kolliderar med ett spöke
    {
        if (PacManScript.eat == true && other.gameObject.tag == "Pacmansnamn") 
        {
                flee = false;
                Eaten();
                
        }
    }

    void Roaming() 
	//Metod för agenternas vandringsläge.
	//Skapar en instans som tar en agents startkordinat och lägger till en slumpmässig kordinat,
    //detta resultat används sedan som argument när NewDestination() metoden kallas.
    {
       
        Vector3 destination = startPosition + new Vector3(Random.Range(-xWRange, xWRange), 0, Random.Range(-zWRange, zWRange));
        NewDestination(destination);
        
    }

    public void NewDestination(Vector3 nyPos) 
	// Sänder agenten till en punkt i kordinatsystemet.
    {
        ghost.SetDestination(nyPos);
    }

    void startRoaming() 
	//Metod för att starta igång Roaming() metoden.
	//Den säger åt roamingDelayTimer variabeln att räkna ner och så fort den når 0 startar Roaming() metoden.
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

  
    void Attack() 
	//Metod för att få agenterna att jaga PacMan
    {
        ghost.SetDestination(pacMan.transform.position);
        ghost.GetComponent<Collider>().enabled = true;

        if (gameObject.name == "Spöke3")
        {
            ghost.speed = 5.0f;
        }

        if (gameObject.name == "Spöke1")
        {
            ghost.speed = 2f;
        }
      
    }

    public void Flee() 
	//Metod för att få agenterna att fly från PacMan, 
	//de har varsitt hörn som flyktposition.
    {
              
        if (flee)
			/* Kordinaterna måste ändras beroende spöken vi har
			på hur många och var vi vill att dem ska gå */
        {
			//Spöke1
			ghost.SetDestination(new Vector3(x,y,z));
           
            if (gameObject.name == "Spöke2")
            {
               
				ghost.SetDestination(new Vector3(x,y,z));
            }

            if (gameObject.name == "Spöke3")
            {
          
				ghost.SetDestination(new Vector3(x,y,z));
            }

            if (gameObject.name == "Spöke4")
            {
                
				ghost.SetDestination(new Vector3(x,y,z));
            }
        }
        


    }

    void Eaten() 
	/* Metod för när spökena blir "uppätna" av pacman. Byter färg-index, ökar agentens hastighet,
    stänger av collidern för att undvika krock med andra agenter samt skickar hem spöket till startpositionen.*/
    {
        

        if (ghost.transform.position != startPosition)
        {
            ghost.GetComponent<Collider>().enabled = false;
            ghost.speed = 10.0f;
            NewDestination(startPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distFromPac = Vector3.Distance(ghost.transform.position, pacMan.transform.position);

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

        

        if (gameObject.name == "Spöke2") 
        {
           if (distFromPac <= distanceToAttack)
            {
               
				ghost.SetDestination(new Vector3(x,y,z));
            }
        }

        if (gameObject.name == "Spöke1")
        {
            Attack();
            
        }

        if (gameObject.name == "Spöke3")
        {
            if (distFromPac <= 2.5f)
            {
                Attack();
            }
        }

        }

       
        
        
    }
}
