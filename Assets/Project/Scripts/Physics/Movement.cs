using UnityEngine;

namespace Armyio.InputSystem
{
    public class Movement : MonoBehaviour, IMovementMode
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] [Min(0)] private float _speed;

        public bool IsStanding => _rigidbody.velocity == Vector3.zero;
        
        public void Move(Vector3 direction) => _rigidbody.velocity = direction * _speed;
    }
}