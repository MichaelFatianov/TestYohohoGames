using Leopotam.Ecs;
using YohohoTest;

public class PlayerAnimationSystem : IEcsRunSystem
{
    private EcsFilter<Player, PlayerViewRef, ItemStorage> _filter;

    public void Run()
    {
        foreach (var index in _filter)
        {
            ref var view = ref _filter.Get2(index).View;
            ref var player = ref _filter.Get1(index);
            ref var storage = ref _filter.Get3(index);
            var animator = view.Animator;
            animator.SetBool("IsMoving", player.isMoving);

            var isHolding = storage.BoundedStack.Count > 0;
            animator.SetBool("IsHolding", storage.BoundedStack.Count > 0);
            var armsWeight = isHolding ? 1f : 0f;
            animator.SetLayerWeight(1, armsWeight);
            
        }
    }
}
