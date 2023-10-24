using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI time;
    [SerializeField]TextMeshProUGUI score;
    [SerializeField]Slider healthSlider;

    [SerializeField]Health health;
    ScoreKeeper scoreKeeper;
    float timerS=0;
    int timerM=0;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        healthSlider.maxValue = health.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "SCORE:"+scoreKeeper.GetScore().ToString();
        healthSlider.value = health.GetHealth();
        
        time.text = getTimeofPlay();
    }

    private string getTimeofPlay()
    {
        if (timerS <= 60)
        {
            timerS += Time.deltaTime;
        }
        else
        {
            timerM++;
            timerS = 0;
        }
        return "TIME: "+timerM.ToString("00")+":"+((int)timerS).ToString("00");

    }
}
