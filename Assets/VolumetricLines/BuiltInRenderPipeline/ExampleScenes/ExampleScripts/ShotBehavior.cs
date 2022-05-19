using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	[SerializeField] private float _shotSpeed;

	void Start () {
	
	}
	
	void Update () {
		transform.position += transform.forward * Time.deltaTime * _shotSpeed;
	
	}
}
