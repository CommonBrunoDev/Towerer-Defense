using UnityEngine;

public class Turret : MonoBehaviour
{
    public enum TurretType
    {
        Damage,
        Enpower,
        Other
    }

    public TurretType type;
    public TurretBase parent;
    public bool placed = false;
}
