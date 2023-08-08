using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helloworld : MonoBehaviour 
{
	int x = 0;

	void Start () 
    {
		
	}
	void Update () 
    {
		print("Helloworld " + x);
		x++;
	}
}
