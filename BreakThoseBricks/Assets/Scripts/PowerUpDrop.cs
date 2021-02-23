using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PowerUpDrop : MonoBehaviour
{

    public BasePowerUp PowerUpPrefab;

    void OnCollisionEnter2D(Collision2D c)
    {
        GameObject.Instantiate(PowerUpPrefab, this.transform.position, Quaternion.identity);
    }
}
