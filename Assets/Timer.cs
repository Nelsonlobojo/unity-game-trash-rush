using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text textDisplay;
    public int timeLeft = 30;
    public bool timerOn = false;    

    void Start()
    {
      textDisplay.text = "00:"+ timeLeft.ToString();  
    }

    // Update is called once per frame
    void Update()
    {
       if(timerOn == false && timeLeft > 0)
       {
           StartCoroutine(Countdown());
       } 
    }

    IEnumerator Countdown()
    {
        timerOn = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        if(timeLeft <10){
            textDisplay.text = "00:0" + timeLeft.ToString();
        }
        else{
            textDisplay.text = "00:" + timeLeft.ToString();
        }
        timerOn = false;
    
    }
}
