using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.right*100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody&&collision.rigidbody.tag == "Player") collision.rigidbody.GetComponent<power>().damage(0.5f);
        GameObject.Destroy(transform.gameObject ,0);
        
    }
}
