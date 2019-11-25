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
    public bool isStart = false;
    PlayerManager playerManager;
    public void FirstInitialization()
    {
        PlayerManager.Instance.FirstInitialization();
        WallManager.Instance.FirstInitialization();
        GuiManager.Instance.FirstInitialization();
    }
    //like start func
    public void SecondInitialization()
    {
    }
    public void Refresh()
    {
        GuiManager.Instance.Refresh();
        if (isStart)
        {
            PlayerManager.Instance.Refresh();
        }
    }
    public void PhysicsRefresh()
    {
        if (isStart)
        {
            PlayerManager.Instance.PhysicsRefresh();
            WallManager.Instance.PhysicsRefresh();
        }
    }
}
