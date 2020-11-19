using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Canvas gameHUD;
    private bool win = false;
    public Text timetext;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(gameHUD);
        startTime = Time.timeSinceLevelLoad;
    }


    // Update is called once per frame
    void Update()
    {
        if (win)
            return;

        float t = Time.timeSinceLevelLoad - startTime;

        string minutes = ((int)t / 60).ToString();
        var minuteTest = ((int)t / 60);
        string seconds = (t % 60).ToString("f2");

        

        if (minuteTest == 0)
            timetext.text = seconds;
        else
            timetext.text = minutes + "." + seconds;

    }

    public void Finish()
    {
        win = true;
        timetext.color = Color.yellow;
    }
}
