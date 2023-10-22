using Leopotam.Ecs;
using UnityEngine;
using YohohoTest;

public class SpawnZoneSystem : IEcsRunSystem
{

    float _timer;
    private EcsWorld _world;
    private Settings _settings;

    private EcsFilter<CaseSpawn> _spawnFilter;
    private EcsFilter<StockCase> _stockCaseFilter;

    private Transform _spawnPoint;

    public void Run()
    {
        ref var spawnPoint  = ref _spawnFilter.Get1(0).SpawnPoint;

        _timer += Time.deltaTime;
        if(_timer >= _settings.CaseSpawnTimer)
        {
            _timer = 0;
            var casesInStock = _stockCaseFilter.GetEntitiesCount();
            if (casesInStock < _settings.StackCapacity)
            {
                var rotation = new Vector3(0f, 45f, -90f);
                var caseDelta = new Vector3(0f, 0.25f, 0f);
                var newCase = Object.Instantiate(_settings.MoneyCasePrefab, spawnPoint.position + (caseDelta * casesInStock), Quaternion.Euler(rotation));
                var entity = _world.NewEntity();
                entity.Replace(new MoneyCaseViewRef(newCase)).Replace(new StockCase());
            }            
        }
    }

}

public struct CaseSpawn
{
    public Transform SpawnPoint;
}

public struct StockCase {}

public struct Dispose {}
public struct Pickup {}
