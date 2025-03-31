using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 10;

    public GameObject healthBar;


    public void takedamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        healthBar.transform.localScale = new Vector3(health * 0.1f, 0.1f, 0.1f);
    }
}