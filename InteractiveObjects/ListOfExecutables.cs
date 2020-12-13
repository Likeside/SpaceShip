using System;
using System.Collections;
using Object = UnityEngine.Object;
using Interfaces;

namespace SpaceShip
{
    public class ListOfExecutables : IEnumerator, IEnumerable
    {
        private IExecutable[] _executableObjects;
        private int _index = -1;
        private InteractiveObject _currentInteractiveObject;
        public int ListLength => _executableObjects.Length;

        public ListOfExecutables()
        {
            //Ищем все интерактивные объекты и, если они реализуют интерфейс IExecute, добавляем их в массив
            var interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
            for (var i = 0; i < interactiveObjects.Length; i++)
            {
                if (interactiveObjects[i] is IExecutable executableObject)
                {
                    AddExecutableObject(executableObject);
                }
            }
        }

    
        //Метод добавления объектов, реализующих IExecute в массив
        public void AddExecutableObject(IExecutable executableObject)
        {
            if (_executableObjects == null)
            {
                _executableObjects = new[] {executableObject};
                return;
            }
            Array.Resize(ref _executableObjects, ListLength + 1);
            _executableObjects[ListLength - 1] = executableObject;
        }

        //Индексатор
        public IExecutable this[int index]
        {
            get => _executableObjects[index];
            set => _executableObjects[index] = value;
        }



        #region Имлпементация нумераторов
        public bool MoveNext()
        {
            if (_index == _executableObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public object Current
        {
            get
            {
                return _executableObjects[_index];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    
        #endregion
    }
}