using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    double accelerationX = 0;
    double accelerationY = 0;
    double vitesseX = 0;
    double vitesseY = 0;
    double forceX = 0;
    double forceY = 0;
    double graviter = 0;
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
        throw new System.NotImplementedException();
    }

    public void SecondInitialization()
    {
        throw new System.NotImplementedException();
    }
    void accelerationPoint()
    {
        forceX = 0;
        forceY = 0;
        vitesseX += accelerationX * Time.fixedDeltaTime;
        vitesseY += accelerationY * Time.fixedDeltaTime;
       /* if (accelerationY > 0)
        {*/
            this.transform.Translate(new Vector3(0, (float)vitesseY * Time.fixedDeltaTime, 0));
       /* }
        else*/
            this.transform.position += (new Vector3(0, -9.32f * Time.fixedDeltaTime, 0));
        //pointElasticY += vitesseY * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            forceY += 15;
            graviter -= 15;
        }
        forceY += -9.32;
        //graviter += -9.32;
        accelerationX = forceX;
        accelerationY = forceY;
        
    }
    void rotation()
    {
        float angle = 0;
        //float x = pointToMove.x - rotationPoint.x;
        //float y = pointToMove.y - rotationPoint.y;
        if (Input.GetKey(KeyCode.A))
            angle = -50;
        else if (Input.GetKey(KeyCode.D))
            angle = 50;
            float rotationX = Mathf.Cos(angle * (Mathf.PI / 180)) - Mathf.Sin(angle * (Mathf.PI / 180));
            float rotationY = Mathf.Sin(angle * Mathf.PI / 180) + Mathf.Cos(angle * Mathf.PI / 180);
            //rotationX += rotationPoint.x;
            //rotationY += rotationPoint.y;
            transform.localEulerAngles += new Vector3(0, 0, angle * Time.fixedDeltaTime);
    }
}
