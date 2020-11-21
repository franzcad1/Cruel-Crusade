using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : MonoBehaviour
{
    //Skeleton Shield up mechanic
    //--still under scrutiny--
    public float shieldUpTime = 5f;
    private WaitForSeconds wait;
    // Start is called before the first frame update
    void Start()
    {
        wait = new WaitForSeconds(shieldUpTime);
        StartCoroutine(RaiseShield());

    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator RaiseShield()
    {
        gameObject.tag = "Enemy";
        yield return wait;
        //shield is raised
        gameObject.tag = "Invulnerable";
    }
}
