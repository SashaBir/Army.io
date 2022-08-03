using Armyio.Physics;
using UnityEngine;

namespace Armyio.Entity
{
    public class Soldier : MonoBehaviour, ISoldier
    {
        [field: SerializeField] public Movement Movement { get; private set; }
        
        public void Shoot()
        {
            
        }
    }
}