using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    
    private List<Spawner> spawners = new List<Spawner>();
    public float intervalBetweenSwitches = 3f;
    private float elapsedTime = 0f;

    GameManager _gameManager;
    void Start()
    {   
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        foreach (Transform child in transform)
        {
            Spawner spawner = child.GetComponent<Spawner>();
            if (spawner != null)
            {
                spawners.Add(spawner);
            }
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime >= intervalBetweenSwitches)
        {
        
            elapsedTime = 0f;

        
            SwitchSpawners();
        }
    }


    void SwitchSpawners()
    {
        List<int> indexes = Enumerable.Range(0, spawners.Count).OrderBy(x => Random.Range(0, 100)).ToList();

        int spawnersToActivate = 1 + System.Math.Min(_gameManager.points / 500, 4);

        for (int i = 0; i < indexes.Count; i++)
        {
            int randomIndex = indexes[i];
            spawners[randomIndex].gameObject.SetActive(i < spawnersToActivate);
        };
    }
}
