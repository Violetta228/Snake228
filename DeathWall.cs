using UnityEngine;
using System.Collections;

public class DeathWall : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision collision)
    {
        SnakeLife S = collision.gameObject.GetComponent<SnakeLife>();

        if (S != null)
        {
            S.SnakeDestroy();

        }

        Oleg O = collision.gameObject.GetComponent<Oleg>();

        if (O != null)
        {
           O.OlegDestroy();

        }

    }

}