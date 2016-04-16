﻿using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    // TODO UI
    [SerializeField]
    private int Health;

    public void TakeDamage(int damage) {
        Health -= damage;

        if (Health <= 0)
            Kill();
    }

    public void Kill() {
        Destroy(gameObject);
    }
}