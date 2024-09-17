using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private TextMeshPro dmgShow;
    [SerializeField] private float showSpd;
    private float lifeTime = 1f;

    private void Update()
    {
        transform.position += new Vector3(0, showSpd) * Time.deltaTime;
        if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Setup(int damage)
    {
        dmgShow.text = damage.ToString();
        lifeTime = 1f;
    }
}
