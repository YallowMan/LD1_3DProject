using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public PlayerController playerController;
    public bool isBoosted= false;
    public GameObject SpeedPrefab;

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
        yield return new WaitForSeconds(1);
        ReturnToNormalSpeed();
        
    }
    public void ReturnToNormalSpeed()
    {
        isBoosted = false;
        playerController.speed /= 2;
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.CompareTag("Player"))
        {
            IncreaseSpeed();
            Instantiate(SpeedPrefab, transform.position, Quaternion.identity);
            GetComponent<Renderer>().enabled = false;
        }
    }
}
