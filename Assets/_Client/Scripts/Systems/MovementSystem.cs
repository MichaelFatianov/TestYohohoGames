using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UIElements;

namespace YohohoTest
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerViewRef, Player> _filter = null;

        private InputService _inputService;
        private Settings _settings;

        public void Run()
        {
            ref var playerRef = ref _filter.Get1(0);
            ref var player = ref _filter.Get2(0);

            var input = _inputService.GetInput().normalized;

            var movement = new Vector3(input.x, 0 , input.y);
            var velocity = movement * _settings.PlayerSpeed;
            Debug.Log("qwqwe: " + velocity.magnitude);
            player.Velocity = velocity.magnitude;
            playerRef.View.Controller.Move(velocity);            
            playerRef.View.Mesh.transform.LookAt(playerRef.View.transform.position + movement);
        }
    }
}
