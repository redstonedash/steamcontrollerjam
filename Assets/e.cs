using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e : MonoBehaviour
{
    Rigidbody r ;
    float error
        ;
    // Start is called before the first frame update
    void Start()
    {
        r=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       A(new Vector3(Input.GetAxis("h"),0 ,Input.GetAxis("v")),10,2);
        //Input.mousePosition   
        RaycastHit hit;
        Ray r = new Ray(transform.position, Vector3.down);
        Physics.Raycast(r,out hit);
        Pid(hit.point.y+1.5f,60,-0.5f,-0.25f);
    }
    void A(Vector3 w, float s, float a)
    {
       float c=Vector3.Dot(r.velocity,w);
        float adds = s-c;
        float ace=Mathf.Min(adds,a*s)
            ;
        r.velocity+=ace*w*Time.deltaTime;
        
            }
    void Pid(float t, float p, float i, float d)
    {
                float PIDCorrection;
        error += Time.deltaTime * (transform.position.y - t);

            //P Proportional, difference multiplied by a force
            PIDCorrection = (t-transform.position.y)*p;

            //I Intergal, the sum error since this code began
            PIDCorrection += error * i;

            //D Derivitive, the rate of change, or velocity in this case
            PIDCorrection += r.velocity.y * d;
            //print(PIDCorrection);
            r.velocity += new Vector3(0,PIDCorrection * Time.deltaTime,0);
    }
}
