using Interfaces;
using UnityEngine;

namespace SpaceShip.Bullets
{
    public class Bullet: InteractiveObject, IMoveable, IExecutable, ICollisionDamage
    {
        [SerializeField] private Sprite _sprite;
        private BulletData _bulletData;
        private Transform _transform;


      //  public Bullet(Transform instantiatePos, Vector3 targetPos)
      void Start()
      {
         //Стрельбу пока еще не сделал, думаю, откуда получать direction в BulletData
           var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
           _bulletData = new BulletData(_sprite, 10, 10);
           spriteRenderer.sprite = _sprite;
            _transform = gameObject.transform;
            //_transform.position = instantiatePos.position;
        }
        public override void Interaction()
        {
            ApplyDamageOnCollision(_bulletData._damage);
        }

        public void Move(float x, float y)
        {
            var moveVector = new Vector2(x, y) * (_bulletData._moveSpeed * Time.deltaTime);
            _transform.Translate(moveVector);
        }

        public void Execute()
        {
          Move(_bulletData._direction.x,_bulletData._direction.y); 
        }

        public int ApplyDamageOnCollision(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}