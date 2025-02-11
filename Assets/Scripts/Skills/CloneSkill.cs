using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : MonoBehaviour
{
    [SerializeField] private GameObject clonePrefab;

    public void CreateClone()
    {
        GameObject newClone = Instantiate(clonePrefab);
    }
}
