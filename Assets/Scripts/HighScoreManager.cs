using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
     [System.Serializable]
    public class HighScoreEntry
    {
        public string playerName;
        public int score;
    }

    public TextMeshProUGUI highScoreText;

    private HighScoreEntry[] highScores = new HighScoreEntry[5]; // Solo mostraremos los 5 mejores récords

    void Start()
    {
        LoadHighScores();
        UpdateHighScoreText();
    }

    public void SaveHighScore(string playerName, int score)
    {
        // Busca la posición donde insertar la puntuación
        int index = -1;
        for (int i = 0; i < highScores.Length; i++)
        {
            if (score > highScores[i].score)
            {
                index = i;
                break;
            }
        }

        // Si encontramos un lugar donde insertar la puntuación, desplaza los demás récords hacia abajo
        if (index != -1)
        {
            for (int i = highScores.Length - 1; i > index; i--)
            {
                highScores[i] = highScores[i - 1];
            }

            // Inserta el nuevo récord
            highScores[index] = new HighScoreEntry { playerName = playerName, score = score };

            // Guarda los récords actualizados
            SaveHighScores();
            UpdateHighScoreText();
        }
    }

    public bool IsNewRecord(int points){
        bool newRecord = false;
        for (int i = 0; i < highScores.Length; i++)
        {
            if (points > highScores[i].score)
            {
                return true;
            }
        }
        return newRecord;
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

    void SaveHighScores()
    {
        // Guardar los récords en PlayerPrefs
        for (int i = 0; i < highScores.Length; i++)
        {
            PlayerPrefs.SetString("PlayerName" + i, highScores[i].playerName);
            PlayerPrefs.SetInt("Score" + i, highScores[i].score);
        }
        PlayerPrefs.Save();
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
}
