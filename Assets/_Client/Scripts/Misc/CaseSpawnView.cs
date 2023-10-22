using Leopotam.Ecs;
using UnityEngine;

public class CaseSpawnView : EntityView
{
    [SerializeField] private Transform _spawnPoint;

    protected override void Initialize(EcsEntity entity)
    {
        entity.Replace(new CaseSpawn { SpawnPoint = _spawnPoint });
    }
}
