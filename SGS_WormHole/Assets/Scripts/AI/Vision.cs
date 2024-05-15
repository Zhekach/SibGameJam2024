using System;
using AI;
using UnityEngine;

[Serializable]
public class Vision : MoveToGoalBehaviorNode
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private float _distance = 3;
    
    private const string PLAYER_LAYER = "Player";
    private const string TRANSPARENT_LAYER = "Obstacle";

    private int _layerPlayer;
    private int _transparentLayers;
    private Vector3 TransformPosition => _agent.transform.position;

    public override void Construct()
    {
        // _nextNod = new Hearing();
        base.Construct();
        _layerPlayer = LayerMask.NameToLayer(PLAYER_LAYER);
        _transparentLayers = (1 << LayerMask.NameToLayer(PLAYER_LAYER)) | (1 << LayerMask.NameToLayer(TRANSPARENT_LAYER));
    }

    public override bool Condition()
    {
        if(_target == null)
            return false;

        Vector3 direction = _target.position - TransformPosition;
        /*direction.y += TransformPosition.y;
        direction = direction.normalized;*/
        
        // Debug.DrawLine(_transform.position, direction * _distance, Color.red);
        /*RaycastHit2D hit = Physics2D.Raycast(_transform.position, direction, _distance, _transparentLayers);

        if (hit.collider != null && hit.transform.gameObject.layer == _layerPlayer)
            return base.Condition();*/
        if (direction.magnitude < _distance)
            return base.Condition();
        
        return false;
    }

    /*public void OnTriggerEnter2D(Collider2D collider) => 
        _target = collider.transform;

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform == _target)
            _target = null;
    }*/
}