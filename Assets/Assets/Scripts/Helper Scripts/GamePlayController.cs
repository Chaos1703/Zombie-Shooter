using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum ZombieGoal{Player , Fence}
public enum GameGoal{killZombie , walkToGoal , defendFence , TimerCountDown , gameOver};
public class GamePlayController : MonoBehaviour
{
    public GameGoal gameGoal = GameGoal.defendFence;
    public static GamePlayController instance;
    [HideInInspector]
    public bool createBulletAndBulletFx , createRocketBullet;
    [HideInInspector]
    public bool PlayerAlive , fenceDestroyed;
    public ZombieGoal zombieGoal = ZombieGoal.Player;
    public GameObject pausePanel , gameOverPanel;
    public int zombieKillCount = 20 , stepCount , timer = 100 , initialStepCount;
    private Transform playerTarget;
    private Vector3 playerPreviousPosition;
    private TextMeshProUGUI zombieKillCountText , stepCountText , timerText;
    private Image playerLife;
    [HideInInspector]
    public int coinCount;


    private void Awake() {
        makeInstance();
        PlayerAlive = true;
        fenceDestroyed = false;
    }

    void Start()
    {
        if(gameGoal == GameGoal.walkToGoal || gameGoal == GameGoal.defendFence){
            playerTarget = GameObject.FindGameObjectWithTag(TagManager.Player_Tag).transform;
            playerPreviousPosition = playerTarget.position;
            initialStepCount = stepCount;
            stepCountText = GameObject.Find("Stepcountertext").GetComponent<TextMeshProUGUI>();
            stepCountText.text = stepCount.ToString();
        }
        if(gameGoal == GameGoal.TimerCountDown){
            timerText = GameObject.Find("Timercountertext").GetComponent<TextMeshProUGUI>();
            timerText.text = timer.ToString();
            InvokeRepeating("decreaseTimer", 0f , 1f);
        }
        if(gameGoal == GameGoal.killZombie){
            zombieKillCountText = GameObject.Find("ZombieCounterText").GetComponent<TextMeshProUGUI>();
            zombieKillCountText.text = zombieKillCount.ToString();
        }
        playerLife = GameObject.Find("LifeFull").GetComponent<Image>();
    }

     void Update()
    {
        if(gameGoal == GameGoal.walkToGoal){
            if(playerPreviousPosition != playerTarget.position){
                countPlayerMovement(); 
            }
        }
    }
    void OnDisable()
    {
        if(instance == this)
            instance = null;
    }
    void makeInstance(){
        if(instance == null)
            instance = this;
    }  
    void decreaseTimer(){
        timer--;
        timerText.text = timer.ToString();
        if(timer <= 0){
            CancelInvoke("decreaseTimer");
            GameOver();
        }
    }
    public void ZombieDied(){
        zombieKillCount--;
        zombieKillCountText.text = zombieKillCount.ToString();
        if(zombieKillCount <= 0){
            CancelInvoke("decreaseTimer");
            GameOver();
        } 
    }
    public void playerLifeCounter(float fillPercentage){
        fillPercentage = fillPercentage / 100f;
        playerLife.fillAmount = fillPercentage;
    }
    public void countPlayerMovement(){
        Vector3 playerTempPosition = playerTarget.position;
        float distance = Vector3.Distance(new Vector3 (playerTempPosition.x, 0f , 0f) , new Vector3 (playerPreviousPosition.x , 0f , 0f));
        if(playerTempPosition.x > playerPreviousPosition.x){
            if(distance > 1f){
                stepCount--;
                if(stepCount <= 0){
                    GameOver();
                }
                playerPreviousPosition = playerTarget.position;
            }
        }
        else if(playerTempPosition.x < playerPreviousPosition.x){
            if(distance > 0.8f){
                stepCount++;
                if(stepCount >= initialStepCount){
                    stepCount = initialStepCount;
                }
                playerPreviousPosition = playerTarget.position;
            }
        }
        stepCountText.text = stepCount.ToString();
    }
    public void pauseGame(){
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    } 

    public void resumeGame(){
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }   

    public void QuitGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver(){
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
