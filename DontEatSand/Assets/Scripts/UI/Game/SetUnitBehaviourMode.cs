using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DontEatSand.Entities.Units;
using DontEatSand;

public class SetUnitBehaviourMode : MonoBehaviour
{

    public void SetUnitToAttack()
    {
        foreach (Unit unit in RTSPlayer.Instance.SelectedUnits)
        {
            unit.behaviourMode = Mode.ATTACK;
        }

    }
    public void SetUnitToDefend()
    {
        foreach (Unit unit in RTSPlayer.Instance.SelectedUnits)
        {
            unit.behaviourMode = Mode.DEFEND;
        }

    }
}
