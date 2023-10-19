using Leopotam.Ecs;
using UnityEngine;
using YohohoTest;

public class EcsContext : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _updateSystems;

    private bool _ecsSystemsInitialized = false;

    void Awake()
    {
        _world= new EcsWorld();

        InitializeSystems();
    }

    void InitializeSystems()
    {
        _updateSystems = new EcsSystems(_world);

        var inputService = new InputService();

        _updateSystems
                .Add(new MovementSystem())
                .Add(new PickupSystem())              
                .OneFrame<OnPickup>()
                .OneFrame<OnGiveAway>()                
                .Inject(inputService)
                ;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_ecsSystemsInitialized) return;
        _updateSystems?.Run();
    }
}
