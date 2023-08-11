using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// مدیریت بازی و کاراکتر ها. کاراکتر ها مستقل از این کلاس هستند.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// singletone instance
    /// </summary>
    public static GameManager manager;
    /// <summary>
    /// لیست تمامی کاراکترهای زنده بازی
    /// </summary>
    public List<GameCharacter> Characters = new List<GameCharacter>();

    void Start()
    {
        RigesterCharacters();
        manager = this;
    }

    void RigesterCharacters()
    {
        Characters = FindObjectsOfType<GameCharacter>().ToList();
    }
}
