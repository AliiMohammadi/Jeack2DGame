using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// کلاس مخصوص گلوله داخل بازی
/// </summary>
public class Bullet : MonoBehaviour 
{
	[HideInInspector]
	public Vector2 Direction;

	/// <summary>
	/// زمان که ماندگاری دارد
	/// </summary>
	public float LifeTime = 5;
	/// <summary>
	/// سرعت لحظه ای گلوله
	/// </summary>
	public float Speed = 5;

	void Update () 
    {
		transform.Translate(Direction * Speed * Time.deltaTime);
		Destroy(gameObject, LifeTime);
	}
}
