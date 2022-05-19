using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitter : MonoBehaviour
{
    [SerializeField] private GameObject AsteroidBlue;
    [SerializeField] private float minDelay, maxDelay;

    private float _nextLaunchTime;

    
    void Update()
    {
        if(Time.time > _nextLaunchTime)
        {
            float left = -transform.localScale.x / 2;
            float right = transform.localScale.x / 2;

            float posX = Random.Range(left, right);
            float posY = transform.position.y;
            float posZ = transform.position.z;

            Instantiate(AsteroidBlue, new Vector3(posX, posY, posZ), Quaternion.identity);
            _nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
