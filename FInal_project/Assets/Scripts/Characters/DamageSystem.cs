using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int kickDamage;
    [SerializeField] int punchDamage;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float attackRange;
    public UnityAction OnHurt;
    public UnityAction OnFatalHurt;
    public UnityAction OnMobPunch;
    readonly float moveBack = 2.0f;
    private int damage;
    public int Health { get { return health; } }

    void Awake()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene != 0 && currentScene != 1)
        {
            if (gameObject.layer == 6)
            {
                health = PlayerPrefs.GetInt("Health");
            }
        }
    }

    public void MobPunch()
    {
        damage = punchDamage;
        CheckContact();
    }

    void Kick()
    {
        damage = kickDamage;
        CheckContact();
    }

    void Punch()
    {
        damage = punchDamage;
        CheckContact();
    }

    void DamageRecieve(int damage, bool isRight)
    {
        health -= damage;
        OnHurt?.Invoke();
        var direction = isRight ? moveBack : -moveBack;
        if(gameObject.layer == 7)
        {
            transform.position = new Vector3(transform.position.x + direction, transform.position.y, transform.position.z);
        }
        if (health <= 0)
        {
            OnFatalHurt?.Invoke();
        }
    }

    void CheckContact()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, attackRange, layerMask);
        Debug.Log(enemies.Length);
        if (enemies == null)
        {
            return;
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject == gameObject)
            {
                continue;
            }
            bool isRight = !GetComponent<SpriteRenderer>().flipX;
            if (gameObject.layer == 6)
            {
                if ((isRight && enemies[i].transform.position.x >= gameObject.transform.position.x) || (!isRight && enemies[i].transform.position.x <= gameObject.transform.position.x))
                {
                    if (enemies[i].TryGetComponent<DamageSystem>(out DamageSystem damageSystem))
                    {
                        damageSystem.DamageRecieve(damage, isRight);
                    }
                }
            }
            if (gameObject.layer == 7)
            {
                if ((isRight && enemies[i].transform.position.x <= gameObject.transform.position.x) || (!isRight && enemies[i].transform.position.x >= gameObject.transform.position.x))
                {
                    if (enemies[i].TryGetComponent<DamageSystem>(out DamageSystem system))
                    {
                        system.DamageRecieve(damage, isRight);
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
