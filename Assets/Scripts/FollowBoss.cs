using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowBoss : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    // Start is called before the first frame update

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        boss.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        faceBoss();
    }

    void faceBoss()
    {
        Vector3 bossPosition = boss.transform.position;

        Vector2 direction = new Vector2(
            bossPosition.x - transform.position.x,
            bossPosition.y - transform.position.y);

        transform.up = direction;
    }



}
