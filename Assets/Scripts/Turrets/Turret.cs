using UnityEngine;

public class Turret : MonoBehaviour
{
    public enum TurretType
    {
        Damage,
        Enpower,
        Support,
        Other
    }

    public TurretType type;
}
