
using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;

public class TransferAnimationSystem : IEcsRunSystem
{
    private EcsFilter<TransferAnimation> _filter;

    public void Run()
    {       
        foreach (var index in _filter)
        {
            ref var entity = ref _filter.GetEntity(index);
            ref var transferAnimation = ref _filter.Get1(index);
                           
            var itemView = entity.Get<ItemViewRef>().View;
            var itemTransform = itemView.transform;
            var destination = transferAnimation.Destination;
            var item = itemView.Entity.Get<Item>();
            var delta = Vector3.up * itemView.PositionInStack * 0.25f;

            itemView.gameObject.transform.DOMove(destination.position, 0.25f).SetEase(Ease.OutQuad).OnComplete(() => EndTransition(itemTransform, destination, delta));
        }
    }

    public void EndTransition(Transform itemTransform, Transform placeholder, Vector3 delta)
    {
        itemTransform.parent = placeholder.transform;
        itemTransform.position = placeholder.position + delta;
    }
}
