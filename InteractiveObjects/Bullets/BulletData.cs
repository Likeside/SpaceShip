using UnityEngine;

namespace SpaceShip.Bullets
{
    public class BulletData
    {
        private Sprite _sprite;
        public int _damage;
        public float _moveSpeed;
        public Vector3 _direction;

        public BulletData(Sprite sprite, int damage, float moveSpeed)
        {
            _sprite = sprite;
            _damage = damage;
            _moveSpeed = moveSpeed;
            //_direction = direction; Откуда получать? Если стрелять будут и другие корабли, помимо игрока

        }
        
    }
}