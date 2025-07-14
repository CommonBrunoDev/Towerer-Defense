using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] Transform[] pathPoints;
    public List<Enemy> enemies = new List<Enemy>();

    private static EnemyHandler instance;
    public static EnemyHandler Instance
    {  get { return instance; } }

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        MoveEnemies();

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].IsDead)
            {
                var en = enemies[i];
                enemies.Remove(enemies[i]);
                Destroy(en);
            }
        }
    }

    public void AddEnemy(GameObject enemy)
    {
        if (enemy.GetComponent<Enemy>() != null)
        {
            var en = Instantiate(enemy);
            enemies.Add(en.GetComponent<Enemy>());
            en.transform.position = pathPoints[0].position;
        }
        else
        { Debug.LogError("ENEMY NOT SET"); }
    }
    private void MoveEnemies()
    {
        foreach (var enemy in enemies)
        {
            if (!enemy.IsDead)
            {
                var movDir = (pathPoints[enemy.currentIndex].position - enemy.transform.position).normalized;
                var movPower = enemy.speed * Time.deltaTime;
                enemy.rb.linearVelocity = (enemy.rb.linearVelocity * 3 + movDir * movPower) / 4;
                enemy.distanceTravelled += movPower;

                if (Vector3.Distance(enemy.transform.position, pathPoints[enemy.currentIndex].position) < 1)
                {
                    if (enemy.currentIndex == pathPoints.Length - 1)
                    {
                        GameManager.Instance.TakeDamage(enemy.damage);
                        enemy.IsDead = true;
                    }
                    enemy.currentIndex++;
                    enemy.rb.linearVelocity *= 0.5f;

                    enemy.transform.rotation = Quaternion.Lerp(enemy.transform.rotation, Quaternion.LookRotation((pathPoints[enemy.currentIndex].transform.position - enemy.transform.position).normalized), Time.deltaTime);
                }
            }
        }
    }
}
