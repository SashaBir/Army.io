using System;
using Armyio.Physics;
using UnityEngine;
using Zenject;

namespace Armyio.Entity
{
    public class PlayerTeam : Team
    {
        private IDirection _direction;

        [Inject]
        private void Construct(IDirection direction) => _direction = direction;

        private void Update()
        {
            Vector3 direction = _direction.Direction;
            if (direction == Vector3.zero)
                return;
            
            Move(direction);
        }
    }
}