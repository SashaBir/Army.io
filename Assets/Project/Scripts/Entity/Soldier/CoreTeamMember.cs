using Armyio.InputSystem;
using UnityEngine;

namespace Armyio.Entity
{
    [RequireComponent(typeof(Collider))]
    public class CoreTeamMember : MonoBehaviour, ICoreTeamMember
    {
        public IMovementMode MovementMode { get; set; }
    }
}