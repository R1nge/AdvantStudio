using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int minY, maxY;
    [SerializeField] private float spawnDelay;
    private int[] _positionForRandom;
    private int _index;

    private void Start()
    {
        _positionForRandom = new[] {minY, maxY};
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
        objectToSpawn.transform.localScale = new Vector3(Random.Range(3f, 5), 1, 1);
        Instantiate(objectToSpawn, new Vector3(Random.Range(5f, 7f), GetPositionY(), 0), Quaternion.identity);
    }

    private float GetPositionY()
    {
        _index = _index == 0 ? 1 : 0;

        var chosenValue = _positionForRandom[_index];
        return chosenValue;
    }
}