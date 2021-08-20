using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public void MissionScene()
    {
        SceneManager.LoadScene("Missions");
    }

    public void UpGrade()
    {
        SceneManager.LoadScene("UpGrade");
    }

    public void Quite()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
