using UnityEngine;

public class TurretDamage : Turret
{
    [SerializeField] float fireRate;
    [SerializeField] float range;
    //[SerializeField] Bullet bulletRef;
    //[SerializeField] Enemy[] enemyList;

    private void Start()
    {
        type = TurretType.Damage;   
    }
}
