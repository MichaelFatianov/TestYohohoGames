using Leopotam.Ecs;
using UnityEngine;

namespace YohohoTest
{
    public class PlayerView : EntityView
    {

        [SerializeField] private GameObject _mesh;

        public GameObject Mesh => _mesh; 

        protected override void Initialize(EcsEntity entity)
        {
            var playerRef = new PlayerViewRef(this);
            entity.Replace(playerRef);
        }        
    }
}
