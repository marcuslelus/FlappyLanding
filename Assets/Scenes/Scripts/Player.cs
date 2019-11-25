using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flame;
    public Vector3 acceleration;
    public Vector3 vitesse;
    public Vector3 force;
    public float masse = 10f;
    public float friction = 10f;
    public bool isAlive = true;
    public float vitesseRotation = 100;

    //Points pour collision
    public Vector3[] points;

    void Awake()
    {
        SecondInitialization();
    }
    public void FirstInitialization()
    {
        flame.SetActive(false);
        acceleration = Vector3.zero;
        vitesse = Vector3.zero;
        force = Vector3.zero;
        masse = 50f;
    }

    public void PhysicsRefresh()
    {
        rotation();
        accelerationPoint();
        updatePoints();

    }

    private void updatePoints()
    {
        points[0] = new Vector3(transform.position.x - 0.71f * transform.localScale.x, transform.position.y + 0.75f * transform.localScale.y, 0);
        points[1] = new Vector3(transform.position.x - 0.71f * transform.localScale.x, transform.position.y - 0.6f * transform.localScale.y, 0);
        points[2] = new Vector3(transform.position.x + 0.71f * transform.localScale.x, transform.position.y - 0.6f * transform.localScale.y, 0);
        points[3] = new Vector3(transform.position.x + 0.71f * transform.localScale.x, transform.position.y + 0.75f * transform.localScale.y, 0);

    }

    public void Refresh()
    {
        if(transform.position.x >= 18f || transform.position.x <= -18f || transform.localPosition.y < -2f)
        {
            isAlive = false;
        }
        if (isAlive && transform.localPosition.y > 50)
        {
            Win();
        }
        if (!isAlive)
        {
            Dead();
        }
    }
    public void Dead()
    {
        GameObject explosion = Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"), transform.parent);
        explosion.transform.position = transform.position;
        isAlive = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GuiManager.Instance.StartMenu();
        //gameObject.SetActive(false);

    }
    public void Win()
    {
        isAlive = false;
        //GetComponent<SpriteRenderer>().enabled = false;
        GuiManager.Instance.StartMenuWin();
    }
    public void SecondInitialization()
    {
        points = new Vector3[4];

        points[0] = new Vector3(transform.position.x - 0.71f * transform.localScale.x, transform.position.y + 0.75f * transform.localScale.y, 0);
        points[1] = new Vector3(transform.position.x - 0.71f * transform.localScale.x, transform.position.y - 0.6f * transform.localScale.y, 0);
        points[2] = new Vector3(transform.position.x + 0.71f * transform.localScale.x, transform.position.y - 0.6f * transform.localScale.y, 0);
        points[3] = new Vector3(transform.position.x + 0.71f * transform.localScale.x, transform.position.y + 0.75f * transform.localScale.y, 0);

    }

    void accelerationPoint()
    {
        flame.SetActive(false);

        //Changer la position
        transform.position += vitesse * Time.fixedDeltaTime;
        
        //Change la vitesse
        vitesse += acceleration * Time.fixedDeltaTime;

        //Initialiser le vecteur Force
        force = Vector3.zero;

        if (Input.GetKey(KeyCode.Space))
        {
            flame.SetActive(true);
            force.y += 30 * masse;
            force = transform.TransformDirection(force);
        }
        //Gravité
        force.y -= (9.81f * masse);
        //friction
        force += vitesse * (-friction);
        //Changer l'acceleration
        acceleration = force / masse;
        
    }
    void rotation()
    {
        float angle = 0;
        if (Input.GetKey(KeyCode.A))
            angle = -vitesseRotation;
        else if (Input.GetKey(KeyCode.D))
            angle = vitesseRotation;
        transform.localEulerAngles += new Vector3(0, 0, angle * Time.fixedDeltaTime);
    }

    void OnDrawGizmosSelected()
    {
        // Ligne jaune autour des murs, indique les points de collision. 
        Gizmos.color = new Color(255, 255, 0, 1F);
        Gizmos.DrawLine(points[0], points[1]);
        Gizmos.DrawLine(points[1], points[2]);
        Gizmos.DrawLine(points[2], points[3]);
        Gizmos.DrawLine(points[3], points[0]);
    }
    public void die()
    {
        isAlive = false;
        GameObject explosion = Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"), transform.parent);
        explosion.transform.position = transform.position;
        gameObject.SetActive(false);
    }
    public void Reset()
    {
        transform.localEulerAngles = Vector3.zero;
        transform.localPosition = Vector3.zero;
        acceleration = Vector3.zero;
        vitesse = Vector3.zero;
        force = Vector3.zero;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
