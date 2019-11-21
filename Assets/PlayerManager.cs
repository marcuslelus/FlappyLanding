using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : IManager
{
    #region singleton
    private static PlayerManager instance;
    private PlayerManager() { }
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerManager();
            }
            return instance;
        }
    }
    #endregion
    public Player player;
    public void FirstInitialization()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void PhysicsRefresh()
    {
        player.PhysicsRefresh();
    }

    public void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void SecondInitialization()
    {
        throw new System.NotImplementedException();
    }
}
