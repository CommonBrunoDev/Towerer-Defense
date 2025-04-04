using UnityEngine;

public class TurretEnpower : Turret
{
    [SerializeField] Powerup powerup;

    private void Start()
    {
        type = TurretType.Enpower;
    }
}
