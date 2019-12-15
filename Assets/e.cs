using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e : MonoBehaviour
{
    Rigidbody r ;
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

    }
    void A(Vector3 w, float s, float a)
    {
       float c=Vector3.Dot(r.velocity,w);
        float adds = s-c;
        float ace=Mathf.Min(adds,a*s)
            ;
        r.velocity+=ace*w*Time.deltaTime;
    }
}
