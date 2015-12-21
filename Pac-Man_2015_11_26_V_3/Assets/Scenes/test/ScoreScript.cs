using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public static ScoreScript score;
    public int highScore;
    public int curentScore;
    public string scoreName;
    public float fruitDestroyTimer;
    public float ghostFleeTimer;


	void Start ()
    {
        score = this;
        ghostFleeTimer = 13.37f;
        fruitDestroyTimer = 10;
        highScore = 0;
	}

    
}
