using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private float _HealthRegenAmount;

    public float HealthRegenAmount { get { return _HealthRegenAmount;} }
}
