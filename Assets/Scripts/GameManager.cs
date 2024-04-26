using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int points;
    PlayerStats _playerStats;
    public TextMeshProUGUI pointsText;

    public Slider healthbar;


    public HighScoreManager _highScoreManager;
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    public GameObject enemySpawner;
    public GameObject PlayerGameObject;
    public GameObject ShieldGameObject;
    public GameObject AbsorbGameObject;

    public TMP_InputField playerNameInputField;
    private string playerName; 


    public TextMeshProUGUI endButton;

    public GameObject wrongEffect;
    public GameObject EvolutionEffect;


    public GameObject plant01;
    public GameObject plant02;
    public GameObject plant03;

    public int fase = 0;

    public AudioClip damageSound;
    public AudioClip evolutionSound;

    // Start is called before the first frame update
    void Start()
    {
        playerNameInputField.onValueChanged.AddListener(UpdatePlayerName);
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        pointsText.text = points.ToString("000000");

        healthbar.maxValue = _playerStats.maxHealth;
        healthbar.value = _playerStats.maxHealth;
    }

    public void AddPoint(int pointsToAdd){
        points += pointsToAdd;
        pointsText.text = points.ToString("000000");
        ChangePlanet();
    }

    public void getDamage(int Damage){
        _playerStats.health -= Damage;
        SoundManager.instance.PlaySound(damageSound);
        Instantiate(wrongEffect,gameObject.transform.position,Quaternion.identity,gameObject.transform);
        healthbar.value = _playerStats.health;
        if(_playerStats.health <= 0){
            GameOver();
        }
    }


    public void GameOver(){
        gameOverCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        enemySpawner.SetActive(false);
        PlayerGameObject.SetActive(false);
        ShieldGameObject.SetActive(false);
        AbsorbGameObject.SetActive(false);

        GameObject[] enemiesStill = GameObject.FindGameObjectsWithTag("Bullet");
        if(enemiesStill.Length > 0){
            foreach (GameObject item in enemiesStill)
            {
                Destroy(item); 
            }
        }

        if(!_highScoreManager.IsNewRecord(points)){

            playerNameInputField.gameObject.SetActive(false);
            endButton.text = "Exit";
                   
        }
    }
    public void UpdatePlayerName(string newName)
    {
        playerName = newName;
        Debug.Log(newName);
    }

    public void SavePlayerRecord(){
        if(_highScoreManager.IsNewRecord(points)){
            if(playerName.Length > 3)
            {
            _highScoreManager.SaveHighScore(playerName,points);
            SceneManager.LoadScene("Menu");
           
            }else{
                return;
            }
        }
        else{
            SceneManager.LoadScene("Menu");
        }
    }

    public void ChangePlanet(){
        if(points > 3000 && fase <2){
            fase += 1;
            SoundManager.instance.PlaySound(evolutionSound);
            Instantiate(EvolutionEffect,gameObject.transform.position,Quaternion.identity,gameObject.transform);
            plant02.SetActive(false);
            plant03.SetActive(true);
            PlayerGameObject.transform.localScale = new Vector3(2f,2f,1);
        }else if(points > 1000  && fase <1){
            SoundManager.instance.PlaySound(evolutionSound);
            fase += 1;
            Instantiate(EvolutionEffect,gameObject.transform.position,Quaternion.identity,gameObject.transform);
            plant01.SetActive(false);
            plant02.SetActive(true);
            PlayerGameObject.transform.localScale = new Vector3(1.5f,1.5f,1);
        }
    }

}
