using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    public AidKit aidkitPrefab;
    private AidKit _aidkit;
    public float spawnCooldownMin = 3;
    public float spawnCooldownMax = 9;

    public List<Transform> spawnderPoints;
    // Start is called before the first frame update
    void Start()
    {
     // spawnderPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        if (_aidkit != null) return;
        if (IsInvoking()) return;
        Invoke("CreateAidkit", Random.Range(spawnCooldownMin, spawnCooldownMax));
    }
    private void CreateAidkit()
    {
       _aidkit = Instantiate(aidkitPrefab);
        _aidkit.transform.position = spawnderPoints[Random.Range(0, spawnderPoints.Count)].position;
    }
}
