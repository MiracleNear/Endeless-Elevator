using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBox : MonoBehaviour
{

    public GameObject[] Boxs;
    public GameObject[] SpawnBoxs;
    public GameObject[] Debaf;


    private int _chanceSpawnDebaf;
    private GameObject _currentBox;

    void Start()
    {
        StartCoroutine(spawnBoxs());
        _chanceSpawnDebaf = Random.Range(0, 21);
    }


    IEnumerator spawnBoxs()
    {
        while(true)
        {
            var rnd = Random.Range(0, 21);
            var timeToNextSpawnBoxs = Random.Range(0.25f, 1f);
            if (_chanceSpawnDebaf == rnd) {
                _currentBox = Debaf[0];
            }
            else
            {
                _currentBox = Boxs[rnd % Boxs.Length];
            }
            var spawnPoint = SpawnBoxs[Random.Range(0, SpawnBoxs.Length)];
            Instantiate(_currentBox, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeToNextSpawnBoxs);
        }
        
    }

   
}
