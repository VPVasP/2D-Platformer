using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public GameObject levelCompletedPanel; //refrence to our gameobject
    private void Start()
    {
        levelCompletedPanel.SetActive(false); //we set it to false at the start
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelCompletedPanel.SetActive(true);//we set it to true
            Invoke("RestartLevel",3f); //we restart the level after 3 seconds
        }
    }
    //function to restart the level
    private void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
