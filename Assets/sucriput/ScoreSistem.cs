using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreSistem : MonoBehaviour
{

    public int score = 0;
    private TMP_Text scoreText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "score:0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score:" + score.ToString();
    }
}
