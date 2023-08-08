using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour 
{
	[HideInInspector]
	public Vector2 Direction;

	public float LifeTime = 5;
	public float Speed = 5;

	void Update () 
    {
		transform.Translate(Direction * Speed * Time.deltaTime);
		Destroy(gameObject, LifeTime);
	}
}
