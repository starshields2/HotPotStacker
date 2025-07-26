using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public DataManager _manager;
    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    public float speedBoostTime;
    public float speed = 0;
    public float speedMultiplier;
    public bool speedBoostOn;

    public GameObject magnet;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ingredient")
        {
            SpawnedItem ingredient = other.gameObject.GetComponent<SpawnedItem>();
                _manager.scoreUpdate = ingredient.pointValue;
                _manager.UpdateScore();
                Destroy(other.gameObject);
            }

        if(other.tag == "Powerup")
        {
            Powerup powerup = other.gameObject.GetComponent<Powerup>();
            powerup.PickPowerup();
            _manager.UpdateScore();
            Destroy(other.gameObject);
        }
        }

    public void Magnet()
    {
        StartCoroutine(TurnMagnetOn());
    }

    public IEnumerator TurnMagnetOn()
    {
        yield return new WaitForSeconds(5);
    }
    public void SpeedIncrease()
    {
        StartCoroutine(SpeedMultiplierLogic());
    }

    public IEnumerator SpeedMultiplierLogic()
    {
        if (!speedBoostOn)
        {
            speedBoostOn = true;
        speed = speed * speedMultiplier;
        yield return new WaitForSeconds(speedBoostTime);
            speedBoostOn = false; 
        }
       

    }
}