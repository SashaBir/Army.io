using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Armyio.Gameplay
{
    [Serializable]
    public class StackMovement
    {
        [SerializeField] private Transform _initial;

        private CancellationTokenSource _source;
        
        public void SetStack(IEnumerable<Money> monies)
        {
            _source = new CancellationTokenSource();
            Follow(monies.Select(i => i.transform), _source.Token).Forget();
        }

        private async UniTaskVoid Follow(IEnumerable<Transform> position, CancellationToken token)
        {
            
        }
    }
}