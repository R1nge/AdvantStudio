using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int minY, maxY;
    [SerializeField] private float spawnDelay;
    private int[] _positions;
    private int _index;
    private bool _isFirstGame = true;

    private void Start()
    {
        _positions = new[] {minY, maxY};
        StartCoroutine(Spawn_c());
    }

    private IEnumerator Spawn_c()
    {
        while (enabled)
        {
            Spawn();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Spawn()
    {
        prefab.transform.localScale = new(Random.Range(4f, 5f), 1, 1);
        Instantiate(prefab, new(Random.Range(5f, 7f), GetPositionY(), 0), Quaternion.identity);
    }

    private int GetPositionY()
    {
        if (_isFirstGame)
        {
            _isFirstGame = false;
            return _positions[0];
        }

        _index = _index == 0 ? 1 : 0;

        var chosenValue = _positions[_index];
        return chosenValue;
    }
}