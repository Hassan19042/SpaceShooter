﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScoreManager : MonoBehaviour
{

    // The map building is going to look like:
    //
    //	LIST OF USERS -> A User -> LIST OF SCORES for that user
    //

    Dictionary<string, Dictionary<string, int>> playerScores;

    int changeCounter = 0;

    void Start()
    {
    }

    void Init()
    {
        if (playerScores != null)
            return;

        playerScores = new Dictionary<string, Dictionary<string, int>>();
    }

    public void Reset()
    {
        changeCounter++;
        playerScores = null;
    }

    public int GetScore(string username, string scoreType)
    {
        Init();

        if (playerScores.ContainsKey(username) == false)
        {
            // We have no score record at all for this username
            return 0;
        }

        if (playerScores[username].ContainsKey(scoreType) == false)
        {
            return 0;
        }

        return playerScores[username][scoreType];
    }

    public void SetScore(string username, string scoreType, int value)
    {
        Init();

        changeCounter++;

        if (playerScores.ContainsKey(username) == false)
        {
            playerScores[username] = new Dictionary<string, int>();
        }

        playerScores[username][scoreType] = value;
    }

    public void ChangeScore(string username, string scoreType, int amount)
    {
        Init();
        int currScore = GetScore(username, scoreType);
        SetScore(username, scoreType, currScore + amount);
    }

    public string[] GetPlayerNames()
    {
        Init();
        return playerScores.Keys.ToArray();
    }

    public string[] GetPlayerNames(string sortingScoreType)
    {
        Init();

        return playerScores.Keys.OrderByDescending(n => GetScore(n, sortingScoreType)).ToArray();
    }

    public int GetChangeCounter()
    {
        return changeCounter;
    }

    public void DEBUG_ADD_KILL_TO_SCOREBOARD()
    {
        ChangeScore("hassan15", "kills", 1);
    }

    public void DEBUG_INITIAL_SETUP()
    {
        SetScore("Hassan", "kills", 0);
        //SetScore("hassan15", "assists", 345);

        SetScore("Picard", "kills", 1000);
        SetScore("Riker", "deaths", 14345);

        SetScore("Data", "kills", 3);
        SetScore("LaForge", "kills", 2);
        SetScore("Scotty", "kills", 1);


        Debug.Log(GetScore("Hassan", "kills"));
    }

}
