
using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;
using YohohoTest;

public class TransferAnimationSystem : IEcsRunSystem
{

    private EcsFilter<ItemViewRef, Transfer> _filter;

    public void Run()
    {       
        foreach (var index in _filter)
        {
            ref var itemView = ref _filter.Get1(index).View;
            ref var transfer = ref _filter.Get2(index);            

            var itemTransform = itemView.transform;
            var destinationStack = transfer.To;
            var item = itemView.Entity.Get<Item>();

            var delta = Vector3.up * item.PositionInStack * 0.25f;          

            itemView.gameObject.transform.DOMove(destinationStack.ItemPlace.position, 0.2f).SetEase(Ease.OutQuad).OnComplete(() => EndTransition(itemTransform, destinationStack.ItemPlace, delta));                        
        }
    }

    public void EndTransition(Transform itemTransform, Transform placeholder, Vector3 delta)
    {
        itemTransform.parent = placeholder.transform;
        itemTransform.position = placeholder.position + delta;
    }
}
