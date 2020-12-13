using System.Collections.Generic;
using InteractiveObjects.Enemies;
using Interfaces;
using UnityEngine;
using Object = System.Object;
using Random = System.Random;

namespace Factories
{
    public class EnemyAsteroidsFactory: IEnemyFactory
    { 
        private List<EnemyScriptableObject> _listOfEnemyScriptableObjects;
        private Random _random = new Random();

        public EnemyAsteroidsFactory(List<EnemyScriptableObject> listOfEnemyScriptableObjects) //Создание фабрики зависит от списка скриптабл обджектов, хранящих характеристики астероидов
        {
            _listOfEnemyScriptableObjects = listOfEnemyScriptableObjects;
        }
       
        //Фабрика создает астероид, случайно выбирая для него скриптабл обджект из списка. Список получаем из геймконтроллера.
        public IEnemy GetEnemy()
        {
            int randomIndex = _random.Next(0, _listOfEnemyScriptableObjects.Count);
        if (_listOfEnemyScriptableObjects.Count > 0)
        {
            var enemyAsteroid = GameObject.Instantiate(Resources.Load<EnemyAsteroid>("Asteroid"));
            enemyAsteroid.enemyScriptableObject = _listOfEnemyScriptableObjects[randomIndex];
            return enemyAsteroid;
        }
        else
        {
            Debug.Log("No scriptable objects found");
            return null;
        }
        }
    }
}