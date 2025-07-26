using UnityEngine;

public class Powerup : MonoBehaviour
{
    public string itemName;
    public int pointValue;
    
    public DataManager _manager;
    public PlayerController _player;
    public Type _powerupType;
    public enum Type
    {
        None, 
        SpeedBoost,
        Multiplier,
        Magnet,
        TimeSlow,
        Lid,
        BigPot
    }

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Type _powerupType;
        //_powerupType = Type.None;
    }

    void Awake()
    {
        _manager = GameObject.Find("DataManager").GetComponent<DataManager>();
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        SelectPowerupType();
        Debug.Log("Powerup Selected");
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Multiplier()
    {
        _manager.GeneralMultiplier();
    }

    public void SpeedBoost()
    {
        _player.SpeedIncrease();
    }

    public void SelectPowerupType()
    {
        Debug.Log("selecting Powerup");
        _powerupType = (Type)Random.Range(1, 6);
        Debug.Log(_powerupType);
    }

    public void PickPowerup() // chooses powerup based on what enum is set on the prefab.
    {
        switch (_powerupType)
        {
            case Type.None:
                Debug.Log("Warning: No Powerup Type Set!");
                break;
            case Type.SpeedBoost:
                Debug.Log("SPEED BOOST");
                SpeedBoost();
                break;
            case Type.Multiplier:
                Debug.Log("POINT MULTIPLIER!");
                Multiplier();
                break;
            case Type.TimeSlow:
                Debug.Log("TIME SLOW!");
                break;
            case Type.Magnet:
                Debug.Log("MAGNET!");
                break;
            case Type.Lid:
                Debug.Log("LID!");
                break;
            default:
                print("No powerup.");
                break;
        }
    }
}
