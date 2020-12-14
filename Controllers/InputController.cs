using Interfaces;
using UnityEngine;

namespace SpaceShip
{
    public class InputController: IExecutable
    {
        private Player _player;

        public InputController(Player player)
        {
            _player = player;
        }
        public void Execute()
        {
            _player.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}