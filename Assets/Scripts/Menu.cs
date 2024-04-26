using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Menu : MonoBehaviour
{
         [System.Serializable]
    public class HighScoreEntry
    {
        public string playerName;
        public int score;
    }
    public TextMeshProUGUI highScoreText;

    private HighScoreEntry[] highScores = new HighScoreEntry[5]; // Solo mostraremos los 5 mejores récords
    // Start is called before the first frame update
    void Start()
    {
        LoadHighScores();
        UpdateHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene("GamePlay");
    }

        void UpdateHighScoreText()
    {
        // Actualizar el texto para mostrar los récords
        string text = "High Scores:\n";
        for (int i = 0; i < highScores.Length; i++)
        {
            text += highScores[i].playerName + ": " + highScores[i].score.ToString("000000") + "\n";
        }
        highScoreText.text = text;
    }


    void LoadHighScores()
    {
        // Cargar los récords guardados en PlayerPrefs
        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i] = new HighScoreEntry
            {
                playerName = PlayerPrefs.GetString("PlayerName" + i, "Player" + i),
                score = PlayerPrefs.GetInt("Score" + i, 0)
            };
        }
    }
}
