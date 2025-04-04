using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;

public class TurretBase : MonoBehaviour
{
    public List<Turret> stackedTurrets = new List<Turret>();
    public List<Powerup> activePowerups = new List<Powerup>();
    [SerializeField] int maxTurrets = 3;
    private int turretAmount = 0;
    private void Start()
    {

    }
}
