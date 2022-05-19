using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    [SerializeField] private GameObject Explosion;
    [SerializeField] private Rigidbody _asteroidBlueBody;
    [SerializeField] private float _asteroidSpeed;
    [SerializeField] private float _asteroidRotationSpeed;

    private float _size;
  
    void Start()
    {
        _size = Random.Range(0.5f, 1.5f);
        Rigidbody Asteroid = GetComponent<Rigidbody>();
        _asteroidBlueBody.angularVelocity = Random.insideUnitSphere * _asteroidRotationSpeed;

        float speedX = 0;
        if(Random.Range(0, 100f) < 30)
        {
            speedX = _asteroidSpeed * Random.Range(-0.5f, 0.5f);
        }
        _asteroidBlueBody.velocity = new Vector3(speedX, 0, -_asteroidSpeed) / _size;
        Asteroid.velocity = new Vector3(speedX, 0, -_asteroidSpeed) / _size;

        Asteroid.transform.localScale *= _size;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid" || other.tag == "GameBoundary")
        {
            return;
        }
        Instantiate(Explosion, transform.position, Quaternion.identity);

        if (other.tag == "Player")
        {
            Instantiate(Explosion, other.transform.position, Quaternion.identity);
            UIController._isPaused = true;
        }

        UIController.numberScore += 10;

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
