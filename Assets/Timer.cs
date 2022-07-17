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
    public AudioSource timerSound;
    public AudioSource softMusic;

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
        if(timeLeft < 15 && timeLeft >0)
        {
            timerSound.Play();
            timerSound.volume = 0.75f;
            timerSound.volume = Mathf.Lerp(timerSound.volume, 1.0F, 0.25F);
            softMusic.volume = Mathf.Lerp(softMusic.volume, 0.0F, 0.25F);

        }
        else
        {
            timerSound.Stop();
        }
        if(timeLeft == 0)
        {
            softMusic.Stop();
        }
        if(timeLeft <10){
            textDisplay.text = "00:0" + timeLeft.ToString();
        }
        else{
            textDisplay.text = "00:" + timeLeft.ToString();
        }
        timerOn = false;
    
    }
}
