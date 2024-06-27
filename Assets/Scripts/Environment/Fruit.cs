using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private float _hpRegenAmount;

    public float HPRegenAmount { get { return _hpRegenAmount;} }
}
