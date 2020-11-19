using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button playButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(SwitchScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchScene()
    {
        if (GameObject.Find("CharacterSelection") != null)
        {
            Destroy(GameObject.Find("CharacterSelection"));
        }
        if (GameObject.Find("GameController") != null)
        {
            Destroy(GameObject.Find("GameController"));
        }
        if (GameObject.Find("GameHud") != null)
        {
            Destroy(GameObject.Find("GameHud"));
        }
        SceneManager.LoadScene(1);
    }
}
