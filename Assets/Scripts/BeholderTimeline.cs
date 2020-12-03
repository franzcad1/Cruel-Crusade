using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class BeholderTimeline : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knight") || collision.CompareTag("Rogue") || collision.CompareTag("Barbarian"))
        {
            GetComponent<PlayableDirector>().enabled = true;
        }
    }
}
