using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DropsProp", order = 1)]
public class DropsPropsSC : ScriptableObject
{
    public  List<GameObject> props;

    public GameObject heartObj;
}
