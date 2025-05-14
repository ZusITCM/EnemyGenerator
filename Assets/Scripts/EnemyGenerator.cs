using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private List<Spawner> _spawners;

    private readonly float _delay = 2.0f;

    private readonly bool _isSpawning = true;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(nameof(SpawnDelayed), _delay);
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private Spawner GetSpawner() => _spawners[Random.Range(0, _spawners.Count)];

    private IEnumerator SpawnDelayed(float delay)
    {
        WaitForSeconds waitDelay = new(delay);

        while (_isSpawning)
        {
            GetSpawner().Spawn();

            yield return waitDelay;
        }
    }
}
