using UnityEngine;
using System.Collections;
using TMPro; 

public class power : MonoBehaviour
{
    public float hp = 1.0f;
    float armor = 0.0f;
    bool aoe;
    public TMP_Text score;
    private int points;
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
            StartCoroutine(LateCall(other.gameObject));
                }
        if (other.tag == "armor")
        {
            armor += 1.0f;
            StartCoroutine(LateCall(other.gameObject));
        }
        if (other.tag == "aoe")
        {
            aoe=true;
            StartCoroutine(LateCall(other.gameObject));
        }

    }
    IEnumerator LateCall(GameObject o)
    {
        o.SetActive(false);
        yield return new WaitForSeconds(30);

        o.SetActive(true);
        //Do Function here...
    }
    public void damage(float d)
    {
        hp -= d;
        if (hp <= 0)
        {
            points = points + 1;
            score.text = points.ToString();
            Random.seed = System.DateTime.Now.Millisecond;
            hp =1;
            var s=GameObject.FindGameObjectsWithTag("spawn");
            transform.position=s[Random.Range(0,s.Length )].transform.position;
        }
    }
}
