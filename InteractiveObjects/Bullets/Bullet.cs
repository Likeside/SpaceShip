using Interfaces;
using UnityEngine;

namespace SpaceShip.Bullets
{
    public class Bullet: InteractiveObject, IMoveable, IExecutable, ICollisionDamage
    {
        private int _damage;
        private float _moveSpeed;
        private Vector2 _direction;
        
        public override void Interaction()
        {
            ApplyDamageOnCollision(_damage);
        }

        public void Move(float x, float y)
        {
            throw new System.NotImplementedException();
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public int ApplyDamageOnCollision(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}