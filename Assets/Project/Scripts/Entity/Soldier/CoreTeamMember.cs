using Armyio.InputSystem;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Armyio.Entity
{
    [RequireComponent(typeof(Collider))]
    public class CoreTeamMember : MonoBehaviour, ICoreTeamMember
    {
        public IDirectionMovement DirectionMovement { private get; set; }

        public bool IsStanding => DirectionMovement.Direction == Vector2.Zero;
    }
}