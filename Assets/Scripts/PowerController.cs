using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class PowerController : MonoBehaviour
{
    public bool isPowerActive = false;
    public bool isPowerReady = false;
    public float powerPercentage = 0;
    public TextMeshProUGUI powerPercentageUI;
    // Start is called before the first frame update
    void Start()
    {
        powerPercentageUI.SetText(powerPercentage.ToString()+"%");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPowerActive && powerPercentage < 100){
            powerPercentage += (Time.deltaTime * 4);
            var percentageRound = (int)Math.Round(powerPercentage);
            powerPercentageUI.SetText(percentageRound.ToString()+"%");
        }
        if (powerPercentage >= 100){
            this.activatePower();
             powerPercentageUI.SetText("POWER READY");
        }
    }

    public void activatePower(){
        isPowerActive = true;
    }

    public void deactivatePower(){
        isPowerActive = false;
    }

    public bool checkPowerReady(){
        return isPowerReady;
    }

    public void launchPower(){

    }
}
