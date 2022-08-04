using System;
using System.Threading;
using Armyio.Entity;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Armyio.Building
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Zone : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float _delay; 
        
        public event Action OnStarted = delegate { };
        
        public event Action OnEnded = delegate { };
        
        private CancellationTokenSource _tokenSource;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Team team) == false)
                return;

            _tokenSource = new CancellationTokenSource();
            WaitTeam(team, _tokenSource.Token).Forget();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Team team) == false)
                return;
            
            _tokenSource.Cancel();
            OnEnded.Invoke();
        }

        private async UniTaskVoid WaitTeam(Team team, CancellationToken token)
        {
            do
            {
                float expandedTime = 0;

                do
                {
                    if (team.IsStanding == false)
                        expandedTime = 0;
                        
                    expandedTime += Time.deltaTime;

                    await UniTask.Yield(cancellationToken: token);
                }
                while (expandedTime < _delay);

                OnStarted.Invoke();
                await UniTask.WaitWhile(() => team.IsStanding == true, cancellationToken: token);
                OnEnded.Invoke();
            }
            while(token.IsCancellationRequested == false);
        }
    }
}