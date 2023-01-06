using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounterComponent : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    void Start()
    {
        this.scoreText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        this.scoreText.text = "0";
    }

    public void Increase()
    {
        int scoreInInteger = int.Parse(this.scoreText.text) + 1;
        this.scoreText.text = scoreInInteger.ToString();
    }
}
