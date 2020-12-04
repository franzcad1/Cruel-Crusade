using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BeholderTimeline : MonoBehaviour
{
    [SerializeField] private GameObject imp;
    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject skeleton;
    [SerializeField] private GameObject archer;
    [SerializeField] private GameObject balor;
    [SerializeField] private GameObject spawn1;
    [SerializeField] private GameObject spawn2;
    [SerializeField] private GameObject spawn3;
    [SerializeField] public Animator anim;
    public bool isDamageable = false;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        isDamageable = false;
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
            StartCoroutine(FightSequence());
        }
    }

    IEnumerator FightSequence()
    {
        GameObject newEnemy; 
        yield return new WaitForSeconds(2);
        newEnemy = Instantiate(imp, spawn1.transform);
        newEnemy.transform.position = spawn1.transform.position;
        newEnemy = Instantiate(imp, spawn2.transform);
        newEnemy.transform.position = spawn2.transform.position;
        newEnemy = Instantiate(imp, spawn3.transform);
        newEnemy.transform.position = spawn3.transform.position;
        yield return new WaitForSeconds(5);
        isDamageable = true;
        anim.SetBool("Damageable", true);
        yield return new WaitUntil(() => health == 2);
        yield return new WaitForSeconds(2);
        newEnemy = Instantiate(zombie, spawn1.transform);
        newEnemy.transform.position = spawn1.transform.position;
        newEnemy = Instantiate(skeleton, spawn2.transform);
        newEnemy.transform.position = spawn2.transform.position;
        newEnemy = Instantiate(zombie, spawn3.transform);
        newEnemy.transform.position = spawn3.transform.position;
        yield return new WaitForSeconds(5);
        isDamageable = true;
        anim.SetBool("Damageable", true);
        yield return new WaitUntil(() => health == 1);
        yield return new WaitForSeconds(2);
        newEnemy = Instantiate(archer, spawn1.transform);
        newEnemy.transform.position = spawn1.transform.position;
        newEnemy = Instantiate(imp, spawn2.transform);
        newEnemy.transform.position = spawn2.transform.position;
        newEnemy = Instantiate(zombie, spawn3.transform);
        newEnemy.transform.position = spawn3.transform.position;
        yield return new WaitForSeconds(5);
        isDamageable = true;
        anim.SetBool("Damageable", true);
        yield return new WaitUntil(() => health == 0);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(6);
    }
}
