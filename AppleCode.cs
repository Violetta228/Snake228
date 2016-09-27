using UnityEngine;
using System.Collections;

public class AppleCode : MonoBehaviour {
    int TimeDeath = 500;
    int Buff = 0;
	// Use this for initialization
	void Start () {
        float XX = Random.Range(-8, 8);
        float YY = Random.Range(-8, 8);

        this.transform.position = new Vector3(XX, YY, 0);

    }
	
	// Update is called once per frame
	void Update () {
        Buff++
                ;

        if (Buff > TimeDeath) DestroyObject(this.gameObject);
	}


    void OnCollisionEnter(Collision collision)
    {
        SnakeLife S = collision.gameObject.GetComponent<SnakeLife>();

        if (S != null)
        {
            S.AddChank5();//add elem

            S.ScoreSnake+=5;//add score
            S.kolvo++;
            DestroyObject(this.gameObject);//kill apple

        }


        
    }




    void OnCollisionEnter2(Collision collision)
    {

        Oleg O = collision.gameObject.GetComponent<Oleg>();

        if (O != null)
        {
            O.AddChank5();//add elem

            O.ScoreOleg += 5;//add score
            O.kolvo++;
            DestroyObject(this.gameObject);//kill apple
        }
    }
}
