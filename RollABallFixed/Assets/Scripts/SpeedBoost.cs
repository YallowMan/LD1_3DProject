using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public PlayerController playerController;
    public bool isBoosted= false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void IncreaseSpeed()
    {
        isBoosted = true;
        playerController.speed *= 2;
        StartSlowTimer();
    }

    public void StartSlowTimer()
    {
      StartCoroutine(WaittoSlowDown());
      
    }

    IEnumerator WaittoSlowDown()
    {
        yield return new WaitForSeconds(2);
        ReturnToNormalSpeed();
        
    }
    public void ReturnToNormalSpeed()
    {
        isBoosted = false;
        playerController.speed /= 2;
    }
    public void OnTriggerEnter(Collider collision)
    {
       IncreaseSpeed();
       GetComponent<Renderer>().enabled = false;
    }
}
