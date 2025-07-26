using UnityEngine;

[CreateAssetMenu(fileName = "ItemClass", menuName = "Scriptable Objects/ItemClass")]
public class ItemClass : ScriptableObject
{
    public string name;
    public int pointValue;
    public float _fallSpeed;
    public bool isBomb;

    public Rigidbody _rb;
    public MeshRenderer meshRenderer;
}
