using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour {

    public Path path;
    public float Speed = 1;
    public float MaxDistanceToGoal = .1f;
    public int startingPoint = 0;

    private IEnumerator<Transform> _currentPoint;

    public void Start() {
        if (path == null) {
            Debug.LogError("Path cannot be null", gameObject);
            return;
        }

        _currentPoint = path.GetPathEnumerator();

        for (int i = 0; i <= startingPoint; i++)
            _currentPoint.MoveNext();

        if (_currentPoint.Current == null)
            return;

        transform.localPosition = _currentPoint.Current.localPosition;

    }

    public void Update() {

        if (_currentPoint == null || _currentPoint.Current == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);

        var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
        if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
            _currentPoint.MoveNext();
    }
}