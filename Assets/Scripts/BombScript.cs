using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject Bomb;
    [SerializeField] private float _bombSpeed;

    private void Start()
    {
        Rigidbody MissleRigidbody = Bomb.GetComponent<Rigidbody>();
        GameObject player = GameObject.FindWithTag("Player");
        
        if(player != null)
        {
            Vector3 playerPosition = player.transform.position;
            MissleRigidbody.velocity = Vector3.ClampMagnitude(playerPosition.normalized, _bombSpeed);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyJet" || other.tag == "GameBoundary")
        {
            return;
        }
        Instantiate(Explosion, transform.position, Quaternion.identity);

        if (other.tag == "Player")
        {
            Instantiate(Explosion, other.transform.position, Quaternion.identity);
            UIController._isPaused = true;
        }

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
