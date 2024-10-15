using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(int correctScene)
    {
        SceneManager.LoadScene(correctScene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
