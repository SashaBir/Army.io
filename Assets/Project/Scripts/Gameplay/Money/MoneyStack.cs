using System;
using System.Collections.Generic;
using UnityEngine;

namespace Armyio.Gameplay
{
    [Serializable]
    public class MoneyStack
    {
        [SerializeField] private StackMovement _movement;
        [SerializeField] private Transform _container;

        private readonly IList<Money> _monies = new List<Money>();

        public void Add(Money money)
        {
            money.transform.SetParent(_container);
            _monies.Add(money);
            _movement.SetStack(_monies);
        }
    }
}