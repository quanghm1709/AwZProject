using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Data")]
    [SerializeField] public string weaponName;
    [SerializeField] public int weapLv;
    [SerializeField] private int damage;
    [SerializeField] public Sprite weapUI;
    
}
