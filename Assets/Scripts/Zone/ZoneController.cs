using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    [SerializeField] private GameObject sprite;
    [SerializeField] private float size;
    [SerializeField] private float duration;
    private float durationCD;
    private bool wait = false;
    private bool dealNextDmg = true;

    private void Start()
    {
        wait = true;
    }

    private void Update()
    {
        if (wait)
        {
            if (durationCD < duration)
            {
                durationCD += Time.deltaTime;
                size -= Time.deltaTime / 5;
                sprite.transform.localScale = new Vector3(size, size, transform.localScale.z);
            }
            else
            {
                durationCD = 0;
                wait = false;
                Destroy(gameObject);
            }
        }
        float distance = Vector3.Distance(transform.position, PlayerController.instance.transform.position);

        if (distance >= size / 2 && dealNextDmg)
        {
            DamagePlayer();
        }
    }

    public IEnumerator DamagePlayer()
    {
        dealNextDmg = false;
        PlayerController.instance.GetDamage(1);
        yield return new WaitForSeconds(1f);
        dealNextDmg = true;
    }

    public void Setup(float duration)
    {
        wait = true;
        this.duration = duration;
    }


}
