using UnityEngine;
using System.Collections;

public class power : MonoBehaviour
{
    float hp = 1.0f;
    float armor = 0.0f;
    bool aoe;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp > 1.0f)
        {
            hp-= (Time.deltaTime / 60);
        }
        armor = Mathf.Max(0,armor-(Time.deltaTime/60));

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "hp")
        {
            hp+=1.0f;
        }
        if (other.tag == "armor")
        {
            armor += 1.0f;
        }
        if (other.tag == "aoe")
        {
            aoe=true;
        }
    }
}
