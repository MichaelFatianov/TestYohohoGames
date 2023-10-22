using Leopotam.Ecs;
using UnityEngine;

public abstract class EntityView : MonoBehaviour
{
    public void Awake()
    {
        var entity = EcsContext.Instance.World.NewEntity();
        Initialize(entity);
    }

    protected abstract void Initialize(EcsEntity entity);    
}
