using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTracking : MonoBehaviour
{
    private Vector3 cameraPos;
    private Transform player, win;

    private float cameraOffst = 4f;
    private void Awake()
    {
        //player transformunu bulmaya yarýyor.
        player = FindObjectOfType<PlayerController>().transform;
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        //kamera takip ve winde duruþ.
        
        if (win==null)
        {
            win = GameObject.Find("win(Clone)").GetComponent<Transform>();
        }

        if (transform.position.y> player.position.y && transform.position.y>win.position.y+cameraOffst)
        {
            cameraPos = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x, cameraPos.y, -5);
        }
    }
}
