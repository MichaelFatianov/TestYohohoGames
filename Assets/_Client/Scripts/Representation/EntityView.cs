using Leopotam.Ecs;
using UnityEngine;

public abstract class EntityView : MonoBehaviour
{
    private EcsEntity _entity;
    public EcsEntity Entity => _entity;

    public void Awake()
    {
        _entity = EcsContext.Instance.World.NewEntity();
        Initialize(_entity);
    }

    protected abstract void Initialize(EcsEntity entity);    
}
