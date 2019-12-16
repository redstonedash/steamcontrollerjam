using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class e : MonoBehaviour
{

    Rigidbody r ;
    float error
        ;
    public int i;
    public GameObject m;
    // Start is called before the first frame update
    void Start()
    {
        r=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var g = Gamepad.all[i];
        if(new Vector3(g.leftStick.x.ReadValue(), 0, g.leftStick.y.ReadValue()).magnitude>0.3
            )
        { 
        A(new Vector3(g.leftStick.x.ReadValue(), 0, g.leftStick.y.ReadValue()), 10,2);
        }
        if (new Vector3(g.rightStick.x.ReadValue(), 0, g.rightStick.y.ReadValue()).magnitude > 0.3
            )
        {
            transform.rotation= Quaternion.Lerp(transform.rotation, Quaternion.LookRotation( new Vector3(g.rightStick.ReadValue().x, 0, g.rightStick.ReadValue().y)), Time.deltaTime*4);
        }
        //Input.mousePosition   
        RaycastHit hit;
        Ray r = new Ray(transform.position, Vector3.down);
        Physics.Raycast(r,out hit);
        Pid(hit.point.y+1.5f,60,-0.5f,-0.25f);
        if (g.rightTrigger.isPressed)
        {
            GameObject.Instantiate(m,transform.position,transform.rotation);
        }
    }
    void A(Vector3 w, float s, float a)
    {
       float c=Vector3.Dot(r.velocity,w);
        float adds = s-c;
        float ace=Mathf.Min(adds,a*s);;
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