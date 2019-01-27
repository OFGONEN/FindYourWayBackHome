using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{

	public Vector3 _movement_distance;
	public float _movement_speed;
	public bool _can_move;

	public bool _on_loop;
	public float _start_after_time;

	public float _wait_time;

	float _next_move;
	bool _on_move;
	bool _go_foward;
	Vector3 _movement_velocity;
	Vector3 _movement_direction;
	Vector3 _movement_startPos_base;
	Vector3 _movement_endPos_base;

	Vector3 _movement_startPos_current;
	Vector3 _movement_endPos_current;


	void Awake()
	{
		_movement_startPos_base = transform.position;
		_movement_endPos_base = _movement_startPos_base + _movement_distance;
		_movement_direction = GetNormalVectorBetweenTwoPoints( _movement_startPos_base, _movement_endPos_base );
		_movement_velocity = _movement_direction * _movement_speed;
		_go_foward = true;
	}

	void Start()
	{
		_next_move = _start_after_time;

		if( _can_move && _next_move == 0)
		{
			MoveFoward();
		}
	}

	void Update()
	{
		if( _on_move )
		{
			transform.Translate( _movement_direction * _movement_speed * Time.deltaTime );
			if( CompareDistance() )
				SnapPos( _movement_endPos_current );
		}
		else if( _can_move && _on_loop && Time.time > _next_move )
		{

			if( _go_foward )
			{
				MoveFoward();
			}
			else
			{
				MoveBackward();
			}
		}
	}

	void MoveFoward()
	{
		_movement_startPos_current = _movement_startPos_base;
		_movement_endPos_current = _movement_endPos_base;
		_movement_direction = GetNormalVectorBetweenTwoPoints( _movement_startPos_base, _movement_endPos_base );
		_movement_velocity = _movement_direction * _movement_speed;

		_on_move = true;

	}

	void MoveBackward()
	{
		_movement_startPos_current = _movement_endPos_base;
		_movement_endPos_current = _movement_startPos_base;
		_movement_direction = GetNormalVectorBetweenTwoPoints( _movement_endPos_base, _movement_startPos_base );
		_movement_velocity = _movement_direction * _movement_speed;

		_on_move = true;
	}

	bool CompareTwoVector( Vector3 myPos, Vector3 destination )
	{
		if( Mathf.Approximately( myPos.x, destination.x ) && Mathf.Approximately( myPos.y, destination.y ) && Mathf.Approximately( myPos.z, destination.z ) )
			return true;

		return false;
	}

	bool CompareDistance()
	{
		if( ( transform.position - _movement_startPos_current ).sqrMagnitude >= _movement_distance.sqrMagnitude )
			return true;

		return false;
	}

	Vector3 GetNormalVectorBetweenTwoPoints( Vector3 start, Vector3 end )
	{
		Vector3 normal = end - start;
		normal = normal.normalized;
		return normal;
	}

	void SnapPos( Vector3 destination )
	{
		transform.position = destination;
		_on_move = false;
		_go_foward = !_go_foward;
		_next_move = Time.time + _wait_time;
	}

	void OnCollisionEnter( Collision collision )
	{
		if( collision.gameObject.tag == "Player" )
		{
			Debug.Log( "Platform collided with Player while waiting" );
			if( !_can_move )
				_can_move = true;

			collision.gameObject.transform.SetParent( gameObject.transform );
		}
	}

	void OnCollisionExit( Collision collision )
	{
		if( collision.gameObject.tag == "Player" )
		{
			collision.gameObject.transform.SetParent( null );
		}
	}
}