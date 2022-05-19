using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    
    [SerializeField] private float _speed;
    private Vector3 _restartPosition;
    private float _positionMinZ;
   
    void Awake()
    {
        _restartPosition = transform.position;
        _positionMinZ = _sprite.bounds.size.z - _restartPosition.z;
    }
   
    void Update()
    {
        transform.Translate(Vector3.back * _speed * Time.deltaTime);
        if(transform.position.z <= -_positionMinZ)
        {
            transform.position = _restartPosition; 
        }
    }
}
