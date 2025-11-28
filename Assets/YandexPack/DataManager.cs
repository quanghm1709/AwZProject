using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using YG;

public class DataManager : Singleton<DataManager>
{
    protected override void Awake()
    {
        base.Awake();
        if (PlayerPrefs.HasKey("first_init"))
        {
            Gold = 500;
            OwnerWeapon = new List<string>();
            _ownerWeapon = new List<string>
            {
                "Base Gun"
            };
        }
    }
    private int _gold { get => YG2.saves.gold; set { YG2.saves.gold = value; YG2.SaveProgress(); } }
    private List<string> _ownerWeapon { get => YG2.saves.ownerWeap; set { YG2.saves.ownerWeap = value; YG2.SaveProgress(); } }
    public int Gold { get => _gold;  set { _gold = value; } }
    public List<string> OwnerWeapon { get => _ownerWeapon; set { _ownerWeapon = value; } }
    //private int _lastUsedSkin { get => YG2.saves.lastUsedSkin; set { YG2.saves.lastUsedSkin = value; YG2.SaveProgress(); } }
    //public int ContinueLevelNumber { get => YG2.saves.continueLevelNumber; set { YG2.saves.continueLevelNumber = value; YG2.SaveProgress(); } }
    //public int GameDifficulty { get => YG2.saves.gameDifficulty; set { YG2.saves.gameDifficulty = value; YG2.SaveProgress(); } }
 
    //public int Fruits { get => _fruits;  set { _fruits = value; } }
    //public int LastUsedSkin { get => _lastUsedSkin;  set { _lastUsedSkin = value; } }

}
