using Armyio.Gameplay;
using Armyio.InputSystem;
using UnityEngine;

namespace Armyio.Entity
{
    public class Soldier : MonoBehaviour
    {
        [field: SerializeField] public Movement Movement { get; private set; }
        
        [field: SerializeField] public Weapon Weapon { get; private set; }
    }
}