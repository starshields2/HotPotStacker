using UnityEngine;

public class SpawnedItem : MonoBehaviour
{
    public string itemName;
    public int pointValue;
    public int pointMult;
    public bool multOn;
    public DataManager _manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointMult = 2;
    }

    void Awake()
    {
        _manager = GameObject.Find("DataManager").GetComponent<DataManager>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
