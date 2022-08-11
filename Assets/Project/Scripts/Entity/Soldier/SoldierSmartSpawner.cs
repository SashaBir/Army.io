using System;
using UnityEngine;

namespace Armyio.Entity
{
    [Serializable]
    public class SoldierSmartSpawner : SoldierSpawner
    {
        [SerializeField] [Min(1)] private float _numberOfCircle;
        [SerializeField] [Min(1)] private float _distance; 
        
        public override Soldier Spawn(Vector3 positionCoreTeamMember) => base.Spawn(FindFreePosition(positionCoreTeamMember));

        private Vector3 FindFreePosition(Vector3 positionCoreTeamMember)
        {
            Vector3? result = null;
            float distance = _distance;
            
            do
            {
                for (float i = 1; i <= _numberOfCircle; i++)
                {
                    Vector3 aroundPosition = new Vector3()
                    {
                        x = (float)Math.Sin(360 / i),
                        y = 0,
                        z = (float)Math.Cos(360 / i)
                    };
                    Vector3 position = positionCoreTeamMember + aroundPosition * distance;
                    
                    result = IsFree(position) == true ? position : null;
                    if (result is not null)
                        break;
                }

                distance += _distance;
            } 
            while (result is null);
            
            return result.Value;
        }

        private bool IsFree(Vector3 position) => Physics.OverlapSphere(position, 0.5f).Length == 0;
    }
}