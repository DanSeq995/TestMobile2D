using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{

    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI multiplierUI;

    public float score = 0;
    public int multiplier;

    // Start is called before the first frame update
    void Start()
    {
        if(VolumeController.isDeveloperMode) {
            multiplier = PlayerPrefs.GetInt("multiplier", 1);
            multiplierUI.SetText("x"+ multiplier.ToString());
        } else {
            multiplier = 1;
            multiplierUI.SetText("x"+ multiplier.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        score += (Time.deltaTime * multiplier);
        
    }

    private void FixedUpdate() {
         var scoreConv = (int)Math.Round(score);
         scoreUI.SetText(scoreConv.ToString());
         
    }

    public void RaiseMultiplier(){
        if (multiplier == 1){
            multiplier += 1;
        }else{
            if(multiplier < 8){
                multiplier = multiplier + 2;
            }
        }
        multiplierUI.SetText("x"+ multiplier.ToString());
    }

    public void ResetMultiplier(){
        multiplier = 1;
        multiplierUI.SetText("x"+ multiplier.ToString());
    }
}
