using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Rigidbody rigid;
    public GameObject sound;
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        sound = transform.Find("player").gameObject;
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        sound.transform.parent = null;
        sound.SetActive(true);
        Destroy(gameObject);
    }
}