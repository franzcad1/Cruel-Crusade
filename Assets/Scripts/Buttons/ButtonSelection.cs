using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonSelection : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button selectButton;
    [SerializeField] private GameObject characterSelect;
    [SerializeField] private string characterChoice;

    // Start is called before the first frame update
    void Start()
    {
        selectButton.onClick.AddListener(SwitchScene2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SwitchScene2()
    {
        characterSelect.GetComponent<CharacterSelection>().characterChoice = this.characterChoice;
        SceneManager.LoadScene(2);
    }
}
