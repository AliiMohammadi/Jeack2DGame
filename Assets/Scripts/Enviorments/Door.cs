using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Door : MonoBehaviour 
{
    [SerializeField]
    private Transform Destination;

    GameObject gesst;

    void OnTriggerEnter2D(Collider2D Tirget)
    {
        if(GameManager.manager.Characters.Exists(x => x.gameObject == Tirget.gameObject))
        {
            gesst = Tirget.gameObject;
        }
    }
    void OnTriggerStay2D(Collider2D Tirget)
    {
        if(gesst == null)
            if (GameManager.manager.Characters.Exists(x => x.gameObject == Tirget.gameObject))
            {
                gesst = Tirget.gameObject;
            }

        if (Input.GetKeyDown(KeyCode.E))
            if (gesst != null)
                
                {
                    Transport(gesst);
                    gesst = null;
                }

    }
    void OnTriggerExit2D(Collider2D Tirget)
    {
        if (gesst == Tirget.gameObject)
            gesst = null;
    }

    /// <summary>
    /// انتقال یک کاراکتر 
    /// </summary>
    /// <param name="passenger"></param>
    public void Transport(GameObject passenger)
    {
        passenger.transform.position = Destination.transform.position;
    }
}
