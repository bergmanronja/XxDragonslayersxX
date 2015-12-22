using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public GameObject gameManager;
    public Text highScoreText;
    public static MenuScript menu;

    void Start()
    {
        menu = this;
        if (GameObject.FindWithTag("Score") == null)
        {
            Instantiate(gameManager, new Vector3(0, 0, 0), Quaternion.identity);
            gameManager = GameObject.FindWithTag("Score");
        }
        
        DontDestroyOnLoad(gameManager.gameObject);
    }

	
	void Update ()
    {
        highScoreText.text = "High Score: " + ScoreScript.score.highScore.ToString() + " " + ScoreScript.score.scoreName;	
	}

    public void quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void startLevel(string name)
    {
        Application.LoadLevel(name);
    }
}
