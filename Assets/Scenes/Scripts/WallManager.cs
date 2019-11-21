using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : IManager
{
    #region singleton
    private static WallManager instance;
    private WallManager() { }
    public static WallManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WallManager();
            }
            return instance;
        }
    }
    #endregion

    List<Wall> walls;

    public void FirstInitialization()
    {
        walls = new List<Wall>();
        foreach(Transform wall in GameObject.FindGameObjectWithTag("Walls").transform)
        {
            walls.Add(wall.GetComponent<Wall>());
        }
    }

    public void PhysicsRefresh()
    {
        foreach (Wall wall in walls)
        {
            wall.PhysicsRefresh();
        }
    }

    public void Refresh()
    {

    }

    public void SecondInitialization()
    {
        throw new System.NotImplementedException();
    }
}
