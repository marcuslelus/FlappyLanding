using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : IManager
{
    #region singleton
    private static GuiManager instance;
    private GuiManager() { }
    public static GuiManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GuiManager();
            }
            return instance;
        }
    }
    #endregion
    BeginButton beginButton;
    ExitButton exitButton;
    Text counter;
    public float timeBeforeStart;
   
    public void FirstInitialization()
    {
        
        beginButton = GameObject.FindGameObjectWithTag("Begin").GetComponent<BeginButton>();
        exitButton = GameObject.FindGameObjectWithTag("Quit").GetComponent<ExitButton>();
        counter = GameObject.FindGameObjectWithTag("Counter").GetComponent<Text>();
        counter.enabled = false;
    }

    public void PhysicsRefresh()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh()
    {
        if(timeBeforeStart != 0)
        {
            startCounter();
        }

    }

    public void SecondInitialization()
    {
        throw new System.NotImplementedException();
    }
    public void StarPosttGame()
    {
        timeBeforeStart = 3.99f;
        counter.enabled = true;
        beginButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        setCounter();
    }
    void StartGame()
    {
        timeBeforeStart = 0;
        GameFlow.Instance.isStart = true;
        counter.enabled = false;
    }
    public void startCounter()
    {
        timeBeforeStart -= Time.deltaTime;
        setCounter();
        if (timeBeforeStart <= 0)
        {
            
            StartGame();
        }
    }
    void setCounter()
    {
        if (counter.text != "Start")
        {
            if (int.Parse(counter.text) != (int)timeBeforeStart )
            {
                counter.text = ((int)timeBeforeStart).ToString();
            }
        }
        if ((int)timeBeforeStart == 0 )
        {
            counter.text = "Start";
        }
    }
}
