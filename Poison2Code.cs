using UnityEngine;
using System.Collections;

public class Poison2Code : MonoBehaviour
{
    int TimeDeath = 1000;
    int Buff = 0;
    // Use this for initialization
    void Start()
    {
        float XX = Random.Range(-8, 8);
        float YY = Random.Range(-8, 8);

        this.transform.position = new Vector3(XX, YY, 0);

    }

    // Update is called once per frame
    void Update()
    {
        Buff += 2
                ;

        if (Buff > TimeDeath) DestroyObject(this.gameObject);
    }


    void OnCollisionEnter(Collision collision)
    {
        SnakeLife S = collision.gameObject.GetComponent<SnakeLife>();

        if (S != null)
        {


            S.ScoreSnake += 3;//add score
            S.kolvo++;

            DestroyObject(this.gameObject);//kill poison

        }
    }
}