using UnityEngine;
using System.Collections;

public class PoisonCode : MonoBehaviour {
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
        Buff ++
                ;

        if (Buff > TimeDeath) DestroyObject(this.gameObject);
    }


    void OnCollisionEnter(Collision collision)
    {
        SnakeLife S = collision.gameObject.GetComponent<SnakeLife>();

        if (S != null)
        {

            S.AddChank4();//add elem
            S.ScoreSnake += 4;//add score
            S.kolvo++;

            DestroyObject(this.gameObject);//kill poison

        }
    }
}