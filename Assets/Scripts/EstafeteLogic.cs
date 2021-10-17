using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EstafeteLogic : MonoBehaviour
{
    [SerializeField] private List<Transform> _runners;
    [SerializeField] private Transform prize;

    private Transform _currentRunner;
    private int _nextPointNumber;
    private float _passDistance = 2.0f;
    private void Start()
    {
        _nextPointNumber = 1;
        _currentRunner = _runners[0];
        _currentRunner.LookAt(_runners[_nextPointNumber]);
    }

    private void Update()
    {
        Transform nextRunnerPosition = _runners[_nextPointNumber];
        _currentRunner.position = Vector3.MoveTowards(_currentRunner.position, nextRunnerPosition.position, 0.1f);

        if (Vector3.Distance(_currentRunner.position, nextRunnerPosition.position) < _passDistance)
        {
            _currentRunner = _runners[_nextPointNumber];
            prize.SetParent(_currentRunner);
            prize.transform.localPosition = Vector3.zero;
            _nextPointNumber += 1;
            
            if (_nextPointNumber == _runners.Count )
            {
                _nextPointNumber = 0;
            }
            _currentRunner.LookAt(_runners[_nextPointNumber]);
        }
    }
}
