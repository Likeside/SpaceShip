using Interfaces;
using UnityEngine;

namespace SpaceShip
{
    public class Player: MonoBehaviour, IMoveable, IExecutable
    {
        public void Move(float x, float y)
        {
            throw new System.NotImplementedException();
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}