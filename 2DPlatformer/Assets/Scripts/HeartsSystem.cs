using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartsSystem : MonoBehaviour
{
    public static HeartsSystem instance;
    private int heartCount = 3;
    [SerializeField] private Image[] hearts;
    [SerializeField] private GameObject EndGameUI;
    private GameObject player;
    //add the listener to our button and make this a singleton
    private void Awake()
    {
        instance = this;
        EndGameUI.GetComponentInChildren<Button>().onClick.AddListener(RestartGame);
    }
    //set the endgameui to false at the start
    private void Start()
    {
        EndGameUI.SetActive(false);
    }
    private void Update()
    {
        //if the hearts are 0 then disable the player and freeze the time
        if (heartCount == 0)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Time.timeScale = 0;
            EndGameUI.SetActive(true);
            player.SetActive(false);
        }
    }
    //lose hearts function
    public void LoseHearts()
    {
        heartCount--;
        hearts[heartCount].gameObject.SetActive(false);
    }
    //restart the scene function
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
