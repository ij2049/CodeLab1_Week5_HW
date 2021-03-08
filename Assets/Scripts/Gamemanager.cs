using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public Text scoreText;
    public static int score;

    private List<int> highScores;
    private string FILE_PATH_HIGH_SCORE;
    private bool isGame = true;
    public static Gamemanager instance;
    
    public int Score //property
    {
        get { return score; }
        set
        {
            score = value; 
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGame) //if we're not in the game, display highscores
        {
            string highScoreString = "High Scores\n\n";

            for (var i = 0; i < highScores.Count; i++)
            {
                highScoreString = highScores[i] + "\n";
            }
            
            scoreText.text = highScoreString;
        }
        
        // for (var i = 0; i < highScores.Count; i++)
        // {
        //     scoreText.text = "Score : " + highScores[i];
        // }
    }

    void UpdateHighScores()
    {
        if (highScores == null)
        {
            highScores = new List<int>();

            string fileContents = File.ReadAllText(FILE_PATH_HIGH_SCORE);

            string[] fileScores = fileContents.Split(',');

            print(fileScores.Length);

            for (var i = 0; i < fileScores.Length; i++)
            {
                highScores.Add(Int32.Parse(fileScores[i]));
            }
        }
        
        

        for (var i = 0; i < highScores.Count; i++)
        {
            if (score > highScores[i])
            {
                highScores.Insert(i, score);
                break;
            }
        }
        string saveHighScoreString = "";

        for (var i = 0; i < highScores.Count; i++)
        {
            saveHighScoreString += highScores[i] + ",";
        }

        File.WriteAllText(FILE_PATH_HIGH_SCORE, saveHighScoreString);
        
    }
}
