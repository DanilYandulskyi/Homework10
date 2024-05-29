using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ColorSeter))]
public class Explosive : Spawner<Explosive>
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private int _spawnChance = 100;
   
    private int _maxSpawningExplosiveCount = 6;
    private int _minSpawningExplosiveCount = 2;
    private int _dividedCoefficient = 2;

    private void OnMouseDown()
    {
        Explode();
    }

    private void Explode()
    {
        if (ChanceGenerator.CalculateChances(_spawnChance))
            SpawnExplosive();

        else
        {
            foreach (Collider collider in GetColliders())
            {
                if(collider.gameObject.TryGetComponent(out Rigidbody rigidbody))
                    rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }

        Destroy(gameObject);
    }

    private void SpawnExplosive()
    {
        int spawningExplosiveCount = Random.Range(_minSpawningExplosiveCount, _maxSpawningExplosiveCount);
        
        for (int i = 0; i < spawningExplosiveCount; i++)
        {
            Explosive clone = Spawn();
            clone.OnSpawn();
        }
    }

    public void OnSpawn()
    {
        _spawnChance /= _dividedCoefficient;
        transform.localScale /= _dividedCoefficient;
    }

    private Collider[] GetColliders()
    {
        return Physics.OverlapSphere(transform.position, _explosionRadius);
    }
}