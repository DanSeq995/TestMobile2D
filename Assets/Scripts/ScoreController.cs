using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{

    public TextMeshProUGUI scoreUI;
    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        
    }

    private void FixedUpdate() {
         var scoreConv = (int)Math.Round(score);
         scoreUI.SetText(scoreConv.ToString());
    }
}
