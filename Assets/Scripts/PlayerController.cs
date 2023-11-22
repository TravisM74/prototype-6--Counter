using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xRange = 7.5f;
    [SerializeField] private float speed = 3;
     [SerializeField] private int centerPointValue = 25; 
     [SerializeField] private int sidePointValue = 5;
    [SerializeField] private int ballCount = 0;
    [SerializeField] private int ballLimit = 10;
    private bool goingRight = true;
    private int score;
    
    public float gameOverDelay = 15;
    private float gameOverTimer = 0;
    private GameObject tenPointScores;
    private GameObject leftPointScores;
    private GameObject rightPointScores;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI BallsPlayed;
    public GameManager gameManager;

    public GameObject BallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        tenPointScores = GameObject.Find("10point");
        leftPointScores = GameObject.Find("leftpoint");
        rightPointScores = GameObject.Find("rightpoint");
        ballCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space) && ballCount < ballLimit ){
            DropBall();
            ballCount++;
            BallsPlayed.text = "Balls : " + ballCount;

        }
        CalculateScore();
        if (ballCount == ballLimit ){

            gameManager.GameOver();
            gameOverTimer += Time.deltaTime;
            BallsPlayed.text = "Game End : " + Mathf.RoundToInt(gameOverDelay - gameOverTimer);
        }
        
    }

    private void CalculateScore(){
        score = (centerPointValue * tenPointScores.GetComponent<Counter>().Count) +
                (sidePointValue * leftPointScores.GetComponent<Counter>().Count) +
                (sidePointValue * rightPointScores.GetComponent<Counter>().Count)
                ;
        ScoreText.text = "Score : " +  score;
    }

    private void DropBall(){
            Instantiate(BallPrefab, transform.position, transform.rotation);  
    }

    private void MovePlayer(){
        if (goingRight){
            transform.position += new Vector3(speed, transform.position.y, transform.position.z) * Time.deltaTime;
        } else {
            transform.position -= new Vector3(speed, transform.position.y, transform.position.z) * Time.deltaTime;
        }
        if  (transform.position.x > xRange){
            goingRight = false;
        }
        if (transform.position.x < - xRange){
            goingRight = true;
        }
    }

    public void GameOver() {

    }
}
