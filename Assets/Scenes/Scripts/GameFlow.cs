using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : IManager
{
    #region singleton
    private static GameFlow instance;
    private GameFlow() { }
    public static GameFlow Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameFlow();
            }
            return instance;
        }
    }
    #endregion
    public void FirstInitialization()
    {
    }
    //like start func
    public void SecondInitialization()
    {
    }
    public void Refresh()
    {
    }
    public void PhysicsRefresh()
    {
    }
}
