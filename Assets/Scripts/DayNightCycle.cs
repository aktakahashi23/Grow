using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro; // text mesh for clock display 
using UnityEngine.Rendering; // access volume component 

public class DayNightCycle : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay; //Display Time
    public TextMeshProUGUI dayDisplay; //Display Day 
    public Volume ppv; // post processing volume 

    public float tick; //increasing the tick -> increases second rate 
    public float seconds;
    public int mins;
    public int hours;
    public int days = 1;

    public bool activateLights; //checks if lights are on 
    public GameObject[] lights; //all lights we want on when dark 
    public SpriteRenderer[] stars; // star sprites


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ppv = gameObject.GetComponent<Volume>(); 
        
    }

    // Update is called once per frame
    void FixedUpdate() // fixed update since update is frame dependent
    {
        CalcTime();
        DisplayTime(); 
    }

    public void CalcTime() // calcuate sec, min and hours
    {
        seconds += Time.fixedDeltaTime * tick; 
        if (seconds >= 60)
        {
            seconds = 0; 
            mins += 1; 
        }
        if (mins  >= 60)
        {
            mins = 0; 
            hours += 1; 
        }
        if (hours >= 24)
        {
            hours = 0;
            days += 1; 
        }
        ControlPPV(); // changes post processing volume after calculation 
    }

    public void ControlPPV() // used to adjust the post processing slider 
    {
        //ppv.weight = 0; 
        if(hours >= 21 && hours < 22) // dusk at 21:00 / 9pm - until 22:00 / 10pm 
        {
            ppv.weight = (float)mins / 60;
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].color = new Color(stars[i].color.r, stars[i].color.g, stars[i].color.b, (float)mins / 60); //change alpha val of stars so become visible 
            }

            if (activateLights == false)
            {
                if(mins > 45 ) // wait until dark 
                {
                    for(int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); // turn lights on 
                    }
                    activateLights = true; 
                }
            }
        }

        if (hours >= 6 && hours < 7) // dawn at 7 - 7
        {
            ppv.weight = 1 - (float)mins / 60;
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].color = new Color(stars[i].color.r, stars[i].color.g, stars[i].color.b, 1 - (float)mins / 60); //change alpha val of stars so become invisible 
            }

            if (activateLights == true)
            {
                if (mins > 45) // wait until bright 
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); // turn lights off 
                    }
                    activateLights = false;
                }
            }
        }

    }
    public void DisplayTime()
    {
        timeDisplay.text = string.Format("{0:00}:{1:00}", hours, mins);
        dayDisplay.text = "Day: " + days; 
    }
}
