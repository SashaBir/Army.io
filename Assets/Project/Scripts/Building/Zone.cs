using UnityEngine;

namespace Armyio.Building
{
    public class Zone : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float _delay;

        private Collider _collider;

        private void Awake()
        {
        }
    }
}