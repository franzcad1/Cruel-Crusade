using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] private GameObject aoeP;

    public float aoeSpread = 4f;
    public int density = 6;
    public float interval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        //spawns aoe damage around a spawn point randomly

        yield return new WaitForSeconds(interval);

        while (true)
        {
            for (int i = 0; i < density; i++)
            {
                Vector2 spawnPosition = new Vector2(firePoint.position.x + Random.Range(-aoeSpread, aoeSpread), firePoint.position.y + Random.Range(-aoeSpread, aoeSpread));
                Instantiate(aoeP, spawnPosition, firePoint.rotation);
            }
            yield return new WaitForSeconds(interval);    
        }
    }
}
