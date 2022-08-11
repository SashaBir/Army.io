using System;
using UnityEngine;

namespace Armyio.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public class Money : MonoBehaviour
    {
        [SerializeField] [Min(1)] private int _price;

        public bool IsCollected { get; private set; } = false;

        public void Collect() => IsCollected = true;

        public void Upload() => IsCollected = false;
    }
}