using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct Charlotte
{
    public short age;
    public bool ecoute;

};

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    double accelerationX = 0;
    double accelerationY = 0;
    double vitesseX = 0;
    double vitesseY = 0;
    public bool isAlive = true;
    uint chiffre = 5;
    float virgule = 5.6f;
    double groschiffre = 4.3;
    bool question = true;
    Vector3 force = Vector3.zero;


    public void FirstInitialization()
    {
    }

    public void PhysicsRefresh()
    {
        rotation();
        accelerationPoint();
    }

    public void Refresh()
    {
        if(transform.position.x >= 18f || transform.position.x <= -18f || transform.localPosition.y < -2f)
        {
            GameObject explosion = Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"), transform.parent);
            explosion.transform.position = transform.position;
            isAlive = false;
            gameObject.SetActive(false);
        }
    }

    public void SecondInitialization()
    {
        throw new System.NotImplementedException();
    }
    void accelerationPoint()
    {
        vitesseX += accelerationX * Time.fixedDeltaTime;
        vitesseY += accelerationY * Time.fixedDeltaTime;
        Vector3 forceCalcul = new Vector3((float)vitesseX, (float)vitesseY, 0);
        this.transform.position += forceCalcul * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            force.y += 90;
            force = transform.TransformDirection(force);
        }
        force.y += (float)-9.32;
        force = force.normalized;
        force *= 3;
        accelerationX = force.x ;
        accelerationY = force.y ;
        
    }
    void rotation()
    {
        float angle = 0;
        if (Input.GetKey(KeyCode.A))
            angle = -100;
        else if (Input.GetKey(KeyCode.D))
            angle = 100;
            transform.localEulerAngles += new Vector3(0, 0, angle * Time.fixedDeltaTime);
    }
}
