using UnityEngine;
using Amigos;

[StateMachine]
public class Miner : MonoBehaviour
{
    [State]
    public class MoveToOreState 
    {
        private float _handsLength = 1f;
        private float _speed = 1f;
        private Ore _ore;
        private Transform _miner;

        public void Enter(Ore ore) => _ore = ore;

        public void Update(float deltaTime) 
        {
            _miner.Translate(_miner.position - _ore.transform.position * _speed * deltaTime);
        }

        [Transition(typeof(MineOreState))]
        public bool ToMineOreState(out Ore ore)
        {
            ore = _ore;

            return Vector3.Distance(ore.transform.position, _miner.position) <= _handsLength;
        }
    }
    
    [State]
    public class MineOreState 
    {
        private Ore _ore;

        public void Enter(Ore ore) => _ore = ore;

        public void Update(float deltaTime)
        {
            _ore.Mine(1);
        }

        [Transition]
        public bool Exit()
        {
            return _ore.Empty;
        }
    }
}
