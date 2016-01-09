using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelect : MonoBehaviour {
    public GameObject LevelSelectImage;
    public GameObject LoadingImage;
    public GameObject PlayImage;
    public GameObject PlayButton;
    public GameObject DocumentOfSkillImage;
    bool cameraPan;
    public GameObject mytarget;
    public Camera MainCamera;
    public float smoothTime = 2f; // The speed of the camera zooming in.
    private Vector3 velocity = Vector3.zero;
   

   void Update()
    {
        // This if statement simply zooms in the camera to a certain point which is a gameobject in the scene. 
        // When the "Character Button" is pressed the bool cameraPan is change to true which then triggers this statement. 
        if (cameraPan == true) 
        {
            
            
            MainCamera.transform.position = Vector3.SmoothDamp(MainCamera.transform.position, 
                mytarget.transform.position, ref velocity, smoothTime);
            
            
        }
        
        }



    /*Each button on the canvas has an assigned value. 
    The corresponding value determines what the button will do what.*/

    public void OnClick(int button)
    {
        /*None level select buttons assigned with the number 1 are buttons that are supposed to bring up
        the level select screen, Buttons in the scene that have this function are the Play buttons*/
        if (button == 1)
        {
            LevelSelectImage.SetActive(true);
            PlayImage.SetActive(false);
            DocumentOfSkillImage.SetActive(false);
        }

        if (button == 2)
        {
            LevelSelectImage.SetActive(false);
            PlayImage.SetActive(true);
        }

        if(button == 3)
        {
            /*The button with number 3 opens the Document Of Skill and changes cameraPan to true
            */
            cameraPan = true;
            MainCamera.GetComponent<LevelSelect>().cameraPan = true;
            DocumentOfSkillImage.SetActive(true);
            PlayImage.SetActive(false);
            
            
        }

        if(button == 4)
        {
            //Quits game when pressed
            Application.Quit();
        }


    }




    /*This function allows the level buttons on the canvas to when clicked on 
    load the scene that has the corrisponding number in the Build Setting
    Example: Level 1 button loads scene 1, Level 5 button loads scene 5*/
    public void LoadScene(int level)
    {
        Application.LoadLevel(level); 
        LoadingImage.SetActive(true);
        /*WARNING:Boss levels needs level numbers assigned to them due to me 
        being unsure what level number the boss levels are.*/
    }


}
