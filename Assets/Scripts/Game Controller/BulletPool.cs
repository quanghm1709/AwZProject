using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;

    public ObjectPool bulletPool;
    public ObjectPool effectPool;
    public ObjectPool enemyBulletPool;

    private void Start()
    {
        instance = this;
    }
}
