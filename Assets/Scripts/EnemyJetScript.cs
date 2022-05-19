using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJetScript : MonoBehaviour
{
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject Bomb;
    [SerializeField] private Transform BombPoint;
    [SerializeField] private float _enemyJetSpeed;
    [SerializeField] private Rigidbody EnemyJet;

    private GameObject Player;
    private float _timeToBomb = 3f;
    private float _timeToNextLaunch = 3f;

    void Start()
    {
        EnemyJet = GetComponent<Rigidbody>();
        EnemyJet.velocity = Vector3.back * _enemyJetSpeed;        
    }

    private void Update()
    {        
        if(Time.time > _timeToBomb)
        {
            Instantiate(Bomb, BombPoint.position, Quaternion.identity);           
            _timeToBomb = Time.time + _timeToNextLaunch;
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

        UIController.numberScore += 20;

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
