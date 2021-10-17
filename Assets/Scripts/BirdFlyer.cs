using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyer : MonoBehaviour
{
    [SerializeField] private List<Transform> points;

    private int _nextPointNumber;
    private int _nextPointDirection;
    private float _passDistance = 0.1f;
    void Start()
    {
        _nextPointNumber = 1;
        _nextPointDirection = 1;
    }

    void Update()
    {
        Transform nextPoint = points[_nextPointNumber];
        transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, 0.1f);

        if (Vector3.Distance(transform.position, nextPoint.position) < _passDistance)
        {
            _nextPointNumber += _nextPointDirection;
            if (_nextPointNumber == points.Count - 1 || _nextPointNumber == 0)
            {
                _nextPointDirection = -_nextPointDirection;
            }
        }
    }
}
