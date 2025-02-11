using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : MonoBehaviour
{
    [SerializeField] private GameObject clonePrefab;

    public void CreateClone(Transform _clonePosition)
    {
        GameObject newClone = Instantiate(clonePrefab);

        newClone.GetComponent<CloneSkillController>().SetupClone(_clonePosition);
    }
}
