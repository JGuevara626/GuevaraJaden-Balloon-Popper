using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomPlatform : MonoBehaviour
{
    public GameObject platform;
    public bool active = false;

    private void Awake()
    {
        platform.SetActive(active);
    }

    private void Update()
    {
        platform.SetActive(active);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            active = !active;
        }
    }

}
