using UnityEngine;

namespace Armyio.Physics
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] [Min(0)] private float _speed;

        public void Move(Vector3 direction) => _rigidbody.velocity = direction * _speed;
    }
}