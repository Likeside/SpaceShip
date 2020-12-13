using System;
using System.Security.Cryptography;
using SpaceShip;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;


namespace InteractiveObjects.Enemies
{
    public class EnemyAsteroid : InteractiveObject, IEnemy, IExecutable, ICollisionDamage, IDestroyable
    {
        public EnemyScriptableObject enemyScriptableObject;
        private Sprite _sprite;
        private float _moveSpeed;
        private int _healthPoints;
        private int _collisionDamage;
        private Transform _transform;
        private Transform _playerTransform;
        private Random _random = new Random();

        public event EventHandler OnDestroyed;
        
        public void Start () //Метод применяет данные из скриптбл обджекта к инстанту объекта, когда фабрика его спавнит. Скриптабл обджект берется рандомный из списка в геймконтроллере

        {
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _sprite = enemyScriptableObject.sprite;
            spriteRenderer.sprite = _sprite;
            _moveSpeed = enemyScriptableObject.moveSpeed;
            _healthPoints = enemyScriptableObject.healthPoints;
            _collisionDamage = enemyScriptableObject.collisionDamage;
            var player = FindObjectOfType<Player>();
            _playerTransform = player.transform;
            var spawnDistanceFromPlayer = new Vector3(Random.Range(-10,10), Random.Range(-10,10), 0); //убрать хардкод
            _transform = gameObject.transform;
            _transform.position = _playerTransform.position + spawnDistanceFromPlayer; //рандомно вычисляется позиция, в которой спавнится астероид, относительно положения игрока
        }


        public int ApplyDamageOnCollision()
        {
            return _collisionDamage;
        }

        public void Execute()
        {
     
            _transform.position = Vector3.MoveTowards(_transform.position, _playerTransform.position, _moveSpeed * Time.deltaTime); //Астероид летит на игрока
        }

        public void Destroy()
        {
            if (this._healthPoints <= 0)
            {
                Destroy(gameObject);
                //OnDestroyed?.Invoke(this, EventArgs.Empty);
            }
        }

        public override void Interaction()
        {
            ApplyDamageOnCollision();
            this._healthPoints = 0;
            Destroy();
        }
    }
}