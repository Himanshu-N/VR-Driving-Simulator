using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReactionTimeManager : MonoBehaviour
{
    [SerializeField] GameObject redImage;
    [SerializeField] TextMeshProUGUI reactionTimeText;
    bool reactionTimeCountToggle, acceptRandomTime;
    float reactionTime, timer, randomTime;
    float maxReactionTime = 5f;

    //Creates the file and adds the reaction time value to it
    void CreateText()
    {
        //Path of the file
        string filePath = @"C:\Users\himan\Documents\Simulator-Reaction-Time-Files\ReactionTimeLog.txt";

        //Create file if it doesn't exists
        if(!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Reaction Time - Session-Wise\n\n");
        }

        if (reactionTimeCountToggle)
        {
            //Content of the file
            string content = ", " + reactionTime.ToString();

            //Add content to the file 
            File.AppendAllText(filePath, content);
        }
        else 
        {
            string content = "\n" + System.DateTime.Now;
            //will run at the start of the game
            File.AppendAllText(filePath, content);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        reactionTimeCountToggle = false;
        redImage.SetActive(false);
        randomTime = GiveRandomTimer();
        CreateText();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Give a random time only once
        if(acceptRandomTime == true)
        {
            randomTime = GiveRandomTimer();
        }

        if (timer >= randomTime)
        {
            redImage.SetActive(true);
            UpdateReactionTime();
        }

        if (reactionTime >= maxReactionTime)
        {
            redImage.SetActive(false);

            //add a default;
            CreateText();

            reactionTimeText.text = reactionTime.ToString("F2"); //Indicate that he had defaulted
            reactionTimeText.color = Color.red; //Indicate that he had defaulted

            //Resetting parameters
            timer = 0;
            reactionTime = 0;
            acceptRandomTime = true;
            reactionTimeCountToggle = false;
        }

        if(reactionTime<maxReactionTime && Input.GetKeyDown(KeyCode.Space) && reactionTimeCountToggle)
        {
            redImage.SetActive(false);

            //add reaction time to file;
            CreateText();

            reactionTimeText.text = reactionTime.ToString("F2"); //Indicate that he successfully pressed the key in time
            reactionTimeText.color = Color.green; //Indicate that he successfully pressed the key in time

            //Resetting parameters
            timer = 0;
            reactionTime = 0;
            acceptRandomTime = true;
            reactionTimeCountToggle = false;
        }
    }

    //Give a random timer value to start countdown for reaction time
    private float GiveRandomTimer()
    {
        float nowStart = UnityEngine.Random.Range(10.2f, 15.8f);
        acceptRandomTime = false;

        Debug.Log("Next Reaction time countdown will occur in: \""+nowStart+"\" seconds.");
        return nowStart;
    }

    //updates reaction time
    private void UpdateReactionTime()
    {
        reactionTimeText.color = Color.white; // to switch back to white coloured text at the start
        reactionTimeCountToggle = true; // to stop random space pressing 

        reactionTime += Time.deltaTime;
        reactionTimeText.text = reactionTime.ToString("F2"); //To count upto 2 decimal places
    }
}
