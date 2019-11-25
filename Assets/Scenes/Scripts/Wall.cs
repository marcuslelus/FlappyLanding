using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Wall : MonoBehaviour, IManager
{
    
    Rect collision;
    Vector3[] points;

    void Awake()
    {
        FirstInitialization();
    }
    public void FirstInitialization()
    {
        points = new Vector3[5];

        points[0] = new Vector3(transform.position.x - 1.395f * transform.localScale.x, transform.position.y + 0.1f * transform.localScale.y, 0);
        points[1] = new Vector3(transform.position.x - 1.395f * transform.localScale.x, transform.position.y - 0.1f * transform.localScale.y, 0);
        points[2] = new Vector3(transform.position.x + 1.395f * transform.localScale.x, transform.position.y - 0.1f * transform.localScale.y, 0);
        points[3] = new Vector3(transform.position.x + 1.395f * transform.localScale.x, transform.position.y + 0.1f * transform.localScale.y, 0);
        points[4] = new Vector3(transform.position.x - 1.395f * transform.localScale.x, transform.position.y + 0.1f * transform.localScale.y, 0);

        /*float x1 = transform.position.x - 1.395f * transform.localScale.x;
        float y1 = transform.position.y + 0.1f * transform.localScale.y;

        float x2 = transform.position.x + 1.395f * transform.localScale.x;
        float y2 = transform.position.y - 0.1f * transform.localScale.y;

        collision = new Rect(x1, y1, 2.79f * transform.localScale.x, -0.2f * transform.localScale.y);
        */
    }

    public bool checkCollision(Vector3 pointToCheck)
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            if(crossProduct(points[i + 1] - points[i], pointToCheck - points[i]) < 0)
            {
                return false;
            }
        }
        return true;
    }

    public float crossProduct(Vector3 one, Vector3 two)
    {
        return (one.x * two.y) - (one.y * two.x);
    }
    public void PhysicsRefresh()
    {
        foreach (Vector3 point in PlayerManager.Instance.player.points)
        {
            if (PlayerManager.Instance.player.isAlive && checkCollision(point) )
            {
                PlayerManager.Instance.player.die();
            }
        }
    }

    public void Refresh()
    {
    }
    
    public void SecondInitialization()
    {
        throw new System.NotImplementedException();
    }

    
    void OnDrawGizmosSelected()
    {
        // Ligne jaune autour des murs, indique les points de collision. 
        Gizmos.color = new Color(255, 255, 0, 1F);
        Gizmos.DrawLine(points[0], points[1]);
        Gizmos.DrawLine(points[1], points[2]);
        Gizmos.DrawLine(points[2], points[3]);
        Gizmos.DrawLine(points[3], points[4]);
    }
}
