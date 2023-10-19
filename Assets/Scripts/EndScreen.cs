using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text bestScore;

    // Start is called before the first frame update
    void Start()
    {
        var score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString();

        var best = PlayerPrefs.GetInt("Best");
        if (score > best)
        {
            PlayerPrefs.SetInt("Best", score);
        }
        bestScore.text = best.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
