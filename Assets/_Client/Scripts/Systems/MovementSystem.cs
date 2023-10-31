using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UIElements;

namespace YohohoTest
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Player, PlayerViewRef> _filter;

        private InputService _inputService;
        private Settings _settings;

        public void Run()
        {
            ref var playerRef = ref _filter.Get2(0);
            ref var player = ref _filter.Get1(0);

            var input = _inputService.GetInput();

            var movement = new Vector3(input.x, 0 , input.y);
            var velocity = movement * _settings.PlayerSpeed * Time.fixedDeltaTime;
            player.isMoving = velocity.magnitude > 0;
            playerRef.View.Controller.Move(velocity);
            playerRef.View.Mesh.transform.LookAt(playerRef.View.transform.position + movement);
        }
    }
}
