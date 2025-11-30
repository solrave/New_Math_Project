using UnityEngine;

public class AngleCheck
{
    private readonly Transform _player;
    private readonly float _fw;

    public AngleCheck(Transform player, float fw)
    {
        _player = player;
        _fw = fw;
    }

    public bool IfSpotted(Transform target)
    {
        // var dotResult = Vector3.Dot( directionToTarget.normalized, _player.forward);
        // var angleDegrees = Mathf.Acos(dotResult) * Mathf.Rad2Deg;
        // Debug.Log("DOT: " + dotResult);
        var directionToTarget = target.position - _player.position;
        var angleDegrees = Vector3.Angle(_player.forward, directionToTarget);
        Debug.Log("ANGLE: " + angleDegrees);
        
            return angleDegrees < (_fw / 2);
    }
}