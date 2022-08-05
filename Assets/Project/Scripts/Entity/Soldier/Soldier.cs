using Armyio.InputSystem;
using UnityEngine;

namespace Armyio.Entity
{
    public class Soldier : MonoBehaviour
    {
        [field: SerializeField] public Movement Movement { get; private set; }
        
        public void Shoot()
        {
            
        }
    }
}