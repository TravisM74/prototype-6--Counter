using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject mainMenuUI;
    
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerMarker").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu(){
        //mainMenuUI.SetActive(true);
        //Time.timeScale = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver(){
        //Debug.Log("In GameOver -gamemanager");
        StartCoroutine("DisplayGameOver");  
    }
    public void Restart(){
        SceneManager.LoadScene("Scene");
        Time.timeScale = 1;
    }

    IEnumerator DisplayGameOver(){
        yield return new WaitForSeconds(player.gameOverDelay);
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void Quit(){
        Application.Quit();
    }

    private void DisplayMainScene(){
        SceneManager.LoadScene("MainScene");
    }
}
