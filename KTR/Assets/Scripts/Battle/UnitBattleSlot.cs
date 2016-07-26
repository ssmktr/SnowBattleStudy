using UnityEngine;
using System.Collections;

public class UnitBattleSlot : MonoBehaviour {

    public UILabel NameLbl;
    public UIProgressBar HpProgressBar;

    public void Init(string _name, float _curHp, float _maxHp)
    {
        NameLbl.text = _name;
        HpProgressBar.value = _curHp / _maxHp;
    }
}
