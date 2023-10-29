using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using YohohoTest;

public class EcsContext : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _updateSystems;

    public static EcsContext Instance;
    public EcsWorld World => _world;

    private bool _ecsSystemsInitialized = false;

    [SerializeField] private AssetReference[] _scenes;
    [SerializeField] private Settings _gameSettings;
    [SerializeField] private ItemsDatabase _itemsDatabase;

    void Awake()
    {
        Instance = this;
        _world= new EcsWorld();
        _updateSystems = new EcsSystems(_world);

#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems);
#endif

        InitializeSystems();
        LoadGameScenes();
    }

    void InitializeSystems()
    { 
        var inputService = new InputService();

        _updateSystems
                .Add(new MovementSystem())
                .Add(new CollisionSystem())
                .Add(new TimerSystem())
                .Add(new SpawnSystem())
                .Add(new ItemTransferSystem())      
                .Add(new TransferAnimationSystem())
                .OneFrame<Collision>()
                .OneFrame<Pickup>()
                .OneFrame<Dispose>()
                .OneFrame<Transfer>()
                .Inject(inputService)
                .Inject(_gameSettings)
                .Inject(_itemsDatabase)
                ;

        _updateSystems.ProcessInjects();
        _updateSystems.Init();

        _ecsSystemsInitialized = true;
    }

    private async void LoadGameScenes()
    {
        foreach(var scene in _scenes)
        {
           scene.LoadSceneAsync(LoadSceneMode.Additive);
        }
    }

    void Update()
    {
        if (!_ecsSystemsInitialized) return;
        _updateSystems?.Run();
    }

    private void OnDestroy()
    {
        if(_updateSystems != null)
        {
            _updateSystems.Destroy();
            _updateSystems = null;
            _world.Destroy();
            _world = null;
        }
    }


}
