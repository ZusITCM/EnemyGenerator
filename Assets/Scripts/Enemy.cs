using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;

    private MeshRenderer _meshRendrer;

    public event Action<Enemy> Despawned;

    private void Update()
    {
        Move();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
            Despawned?.Invoke(this);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void Move()
    {
        transform.Translate(_direction * _speed *  Time.deltaTime, Space.World);
    }
}