using UnityEngine;
using System.Collections;
using UnityEngine.UI;



    public class PointsScript : MonoBehaviour
    {

        int pointsCount;
        public int lives;
        public static PointsScript points;
        int pointsToLife;
        float timer;
        public Text pointsTx;
        public Text livesTx;
        public Text timerTx;
        public Text skullTx;
        public Text gameOverTx;
        public GameObject restart;
        public GameObject startMenu;
        public GameObject inputField;
        public Text nameEnter;
        int ballCount;
    

        void Start()
    {
        points = this;
        lives = 3;
        ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;
        
    }

        //Metod som man kallar på när PacMan kolliderar med ett object som ger poäng.
        public void Points(int points)
        {
            pointsCount += points;

        pointsToLife += points;

        ballCount--;
   
            if (ballCount <= 0)
            {
            ScoreScript.score.curentScore += pointsCount;
            ScoreScript.score.fruitDestroyTimer -= 2;
            ScoreScript.score.ghostFleeTimer -= 1;
            Application.LoadLevel(Application.loadedLevel); 
            }

            if (pointsToLife >= 100)
            {
                lives++;
                pointsToLife -= 100;
            }

        }

    public void StartMenu() //Metod för startmenyn
    {
        ScoreScript.score.curentScore = 0;
        ScoreScript.score.fruitDestroyTimer = 10;
        ScoreScript.score.ghostFleeTimer = 20;
        Application.LoadLevel(0);
        Application.LoadLevel(0);
        Time.timeScale = 1;
    }

    public void Restart() //Metod för restart-knappen 
    {
        ScoreScript.score.curentScore = 0;
        ScoreScript.score.fruitDestroyTimer = 10;
        ScoreScript.score.ghostFleeTimer = 20;
        Application.LoadLevel(0);
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }

    public void SetHighScore() //Metod för att sätta highscore och skriva in ditt namn
    {
        ScoreScript.score.scoreName = nameEnter.text;
        ScoreScript.score.highScore = ScoreScript.score.curentScore;
        ScoreScript.score.curentScore = 0;
        ScoreScript.score.fruitDestroyTimer = 10;
        ScoreScript.score.ghostFleeTimer = 20;
        Application.LoadLevel(0);
        Time.timeScale = 1;
    }

    //Metod som man kallar på när PacMan kolliderar med ett object som dödar PacMan.
    //Spelet pausar när alla liv tar slut, är din poäng det högsta som registrerats sedan spelet startas får du skriva in ditt highscore namn, annars "Game Over"
    public void Damage()
        {
            lives--;

            ScoreScript.score.curentScore += pointsCount;
            
        if (lives <= 0) 
            {
            
            Time.timeScale = 0;
            
            if (ScoreScript.score.highScore < ScoreScript.score.curentScore)
            {
                gameOverTx.enabled = true;
                gameOverTx.text = "High Score!!!";
                inputField.SetActive(true);

            }
            else
            {
                gameOverTx.enabled = true;
                restart.SetActive(true);
                startMenu.SetActive(true);

                gameOverTx.text = "Game Over";
            }
            }
        }

        void Update()
    {
        timer += Time.deltaTime;

        pointsTx.text = "Points: " + pointsCount.ToString();
        livesTx.text = "Lives: " + lives.ToString();
        timerTx.text = "Time: " + timer.ToString();
        skullTx.text = "Skulls Left: " + ballCount.ToString();

        ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;
    }

    }
