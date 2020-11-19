using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject rogue;
    [SerializeField] private GameObject characterSelection;
    [SerializeField] private GameObject barbarian;
    [SerializeField] private GameObject cinemachine;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        characterSelection = GameObject.Find("CharacterSelection");
       

        if (characterSelection.GetComponent<CharacterSelection>().characterChoice == "rogue")
        {
            player = Instantiate(rogue, new Vector2(this.transform.position.x, this.transform.position.y), transform.rotation);
            cinemachine.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        }
        else if (characterSelection.GetComponent<CharacterSelection>().characterChoice == "knight")
        {
            player = Instantiate(knight, new Vector2(this.transform.position.x, this.transform.position.y), transform.rotation);
            cinemachine.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        }
        else if (characterSelection.GetComponent<CharacterSelection>().characterChoice == "barbarian")
        {
            player = Instantiate(barbarian, new Vector2(this.transform.position.x, this.transform.position.y), transform.rotation);
            cinemachine.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
