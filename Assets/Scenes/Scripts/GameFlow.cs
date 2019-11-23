using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : IManager
{
    #region singleton
    private static GameFlow instance;
    private GameFlow() { }
    PlayerManager playerManager;
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
        PlayerManager.Instance.FirstInitialization();
    }
    //like start func
    public void SecondInitialization()
    {
    }
    public void Refresh()
    {
        PlayerManager.Instance.Refresh();
    }
    public void PhysicsRefresh()
    {
        PlayerManager.Instance.PhysicsRefresh();
    }
}
