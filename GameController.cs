using System;
using System.Collections.Generic;
using Factories;
using InteractiveObjects.Enemies;
using Interfaces;
using UnityEngine;

namespace SpaceShip
{
    public class GameController: MonoBehaviour
    {
        [SerializeField] private List<EnemyScriptableObject> _listOfEnemyScriptableObjects;
        [SerializeField] private int _enemyCount;
        private IEnemyFactory _enemyFactory;
        private InteractiveObject[] _interactiveObjects;
        private ListOfExecutables _listOfExecutables;
        
        private void Start()
        {
            _enemyFactory = new EnemyAsteroidsFactory(_listOfEnemyScriptableObjects);
            for (int i = 0; i <= _enemyCount; i++)
            {
                _enemyFactory.GetEnemy();
            }

            _interactiveObjects = FindObjectsOfType<InteractiveObject>();

            _listOfExecutables = new ListOfExecutables();
        }

        private void Update()
        {
            for (int i = 0; i < _listOfExecutables.ListLength; i++)
            {
                var executalbeObject = _listOfExecutables[i];
                if (executalbeObject == null)
                {
                    continue;
                }
                executalbeObject.Execute();
            }
        }
    }
}