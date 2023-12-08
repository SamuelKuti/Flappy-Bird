using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private GameObject bird;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Side Border")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "Bird")
        {
            Destroy(bird);
        }
    }
}
