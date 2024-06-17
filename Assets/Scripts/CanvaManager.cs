using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvaManager : MonoBehaviour
{
    public static CanvaManager instance;
    void Awake(){
        instance = this;
    }
    [SerializeField] TextMeshProUGUI comboText, scoreText, multiplierText;
    public void UpdateCanvaScore(int score, int combo, int multiplier){
        scoreText.text = $"+ {score}";
        comboText.text = $"Combo \n {combo}";
        multiplierText.text = $"x{multiplier}";
    }
}
