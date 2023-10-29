using Leopotam.Ecs;
using UnityEngine;
using YohohoTest;

public class TriggerView : MonoBehaviour
{
    EcsEntity _entity;

    public void Initialize(EcsEntity entity)
    {
        entity.Replace(new Trigger());
        _entity = entity;
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        var otherEntity = other.GetComponent<EntityView>().Entity;
        _entity.Replace(new Collision {Self = _entity, Other = otherEntity});
    }

    public void OnTriggerExit(Collider other)
    {
        
    }
}
