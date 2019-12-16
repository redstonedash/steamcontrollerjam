using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class timer : MonoBehaviour
{
    public TMP_Text timertext;
    public power  p1s, p2s;
    float btimer = 300;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        btimer -= Time.deltaTime;
        float mins = Mathf.Floor(btimer / 60);
        float secs = Mathf.Floor(btimer % 60); 
        timertext.text = mins.ToString() +":" + secs.ToString(); 
        if (p1s.points > p2s.points  && btimer < 0)
        {
            SceneManager.LoadScene(3); 
        }
        else if (btimer < 0) { SceneManager.LoadScene(4); } 
    }
}
