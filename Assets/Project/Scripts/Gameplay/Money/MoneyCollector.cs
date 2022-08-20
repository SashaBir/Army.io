using UnityEngine;

namespace Armyio.Gameplay
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class MoneyCollector : MonoBehaviour
    {
        [SerializeField] private MoneyStack _stack;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out Money money) == false)
                return;

            if (money.IsCollected == true)
                return;

            _stack.Add(money);
        }
    }
}