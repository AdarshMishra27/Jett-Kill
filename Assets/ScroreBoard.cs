using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScroreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreDisplay;

    private void Start() {
        scoreDisplay = GetComponent<TMP_Text>();
        scoreDisplay.text = "START";
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreDisplay.text=score.ToString();
    }
}
