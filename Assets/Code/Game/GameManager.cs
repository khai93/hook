using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Map;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;

    private float accuracy;
    private int score;
    private int combo;

    private int misses;
    private int hit50s;
    private int hit100s;
    private int hit300s;

    private int counter;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ResetScores();
        

        string json = File.ReadAllText(Application.dataPath + "/Assets/Maps/exampleMap.json");
        MapController.Play(json);
    }

    private void ResetScores()
    {
        accuracy = 100f;
        score = 0;
        combo = 0;
        misses = 0;
        hit50s = 0;
        hit100s = 0;
        hit300s = 0;
    }

    public void ProcessScore(float _score)
    {

        if (_score > 0)
        {
            combo++;
        } else
        {
            combo = 0;
            misses++;
        }
        
        if (_score == 50)
        {
            score += 50 + (50 * combo);
            hit50s++;
            Debug.Log("50");
        }

        if (_score == 100)
        {
            score += 100 + (100 * combo);
            hit100s++;
            Debug.Log("100");
        }

        if (_score == 300)
        {
            score += 300 + (300 * combo);
            hit300s++;

            Debug.Log("300");
        }

        counter++;

        accuracy = Mathf.Floor((((hit300s * 2f + hit100s * 1.5f + hit50s+1.25f + misses)+1) / ((counter * 3f)+1))*1000)/10;
 
        accuracyText.text = accuracy.ToString() + "%";
        scoreText.text = score.ToString();
        comboText.text = "x" + combo.ToString();
    }
}
