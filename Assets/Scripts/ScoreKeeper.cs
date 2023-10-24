using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score;

    static ScoreKeeper instance;

    private void Awake()
    {
        ManageSingleton();
    }
    public void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int nScore)
    {
        score += nScore;
        Debug.Log(score);
    }
    public void resetScore() { score = 0; }
}
