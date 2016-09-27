using UnityEngine;
using System.Collections;

public class AutoCode : MonoBehaviour
{
    int TimeDeath = 100;
    int Buff = 0;
    // Use this for initialization
    void Start()
    {
        float XX = Random.Range(-8, 20);
        float YY = Random.Range(-20, 8);

        this.transform.position = new Vector3(XX, YY, 0);

    }

    // Update is called once per frame
    void Update()
    {
        Buff++
                ;

        if (Buff > TimeDeath) DestroyObject(this.gameObject);
    }


    void OnCollisionEnter(Collision collision)
    {
        SnakeLife S = collision.gameObject.GetComponent<SnakeLife>();

        if (S != null)
        {
            S.AddChank();//add elem

            S.ScoreSnake += 10;//add score
            S.kolvo++;

            DestroyObject(this.gameObject);//kill apple

        }
    }
}
