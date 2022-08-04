using UnityEngine;

namespace Armyio.Building
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Zone : MonoBehaviour
    {
        private Collider _collider;
    }
}