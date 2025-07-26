using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
    [Header("Main")]
    public string name;

    [Header("Spawn")]
    [Tooltip("For controlling how many items and what points they spawn at.")]
    public Transform[] _spawnPoints;
    public GameObject[] _items;
    public float coolDownPeriodInSeconds;
    public float spawnSpeed;

    [Header("Style")]
    public MeshRenderer[] _pipes;
    public Material[] _pipeMaterials;
    public Material _regularSpawn;
    public Material _badSpawn;
    public Material _normalColor;

   
    void Start()
    {
        //Just start spawning. Can be moved to invoke wave functions when implemented.
        InvokeRepeating("StartSpawning", 1f, spawnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void RestartSpawnSpeedFast()
    {
        spawnSpeed = spawnSpeed * 3;
        CancelInvoke("StartSpawning");
        InvokeRepeating("StartSpawning", 0f, spawnSpeed);
    }


    public void StartSpawning()
    {
        StartCoroutine(SpawnLogic());
    }

    public IEnumerator SpawnLogic()
    {
        //picks a random pipe #, finds the transform for the spawn point AND the material for the pipe to change its color

        int randomPick = Random.Range(0, 3);
        Transform thisSpawnPipe = _spawnPoints[randomPick];
        MeshRenderer chosenPipe = _pipes[randomPick];
        chosenPipe.material = _pipeMaterials[0];
        //Then, instantiate an item from the list:
        GameObject clone;
        clone = Instantiate(_items[Random.Range(0, _items.Length)], thisSpawnPipe.position, transform.rotation);
        Rigidbody _cloneRB = clone.GetComponent<Rigidbody>();
        _cloneRB.linearVelocity = transform.TransformDirection(Vector3.down * 2);
        //then change pipe color back. 
        yield return new WaitForSeconds(0.5f);
        chosenPipe.material = _pipeMaterials[1];
    }
}
