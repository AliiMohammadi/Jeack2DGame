using UnityEngine;

/// <summary>
/// برنامه ای برای کنترل یک کاراکتر
/// </summary>
public class GameCharacterControler : MonoBehaviour 
{
	private GameCharacter Character;
	public GameObject Target;

	void Start () 
    {
		Character = Target.GetComponent<GameCharacter>();
	}
	void Update () 
    {
        if (Character.IsAlive)
        {
			CheckMovements();
			CkeckAttack();
			CheckSwitchWeapone();
			CheckHoldingGaurd();
		}
	}

	void CheckMovements()
    {
        if (Input.GetKey(KeyCode.A))
        {
			Character.Move(TowDDirections.Left);
			Character.IsMoveing = true;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			Character.Move(TowDDirections.Right);
			Character.IsMoveing = true;
        }
        else
        {
			Character.IsMoveing = false;
		}
	}
	void CkeckAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
			Character.Attack();
        }
    }
	void CheckSwitchWeapone()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Character.SwitchWeapone();
		}
	}
	void CheckHoldingGaurd()
    {
		Character.HoldingGaurd = (Input.GetMouseButton(1));
    }
}
