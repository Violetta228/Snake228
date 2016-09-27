using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Oleg : MonoBehaviour
{
    //kol-vo  yablok ochkov
    public int ScoreOleg = 0;
    //skorost def
    public int TimeSpeed = 15;
    //rost skorosti
    int Buff = 0;

    //hvost 
    public GameObject SnakeBody;
    public GameObject SnakeBody2;
    public GameObject SnakeBody5;
    //telo
    List<GameObject> BodySnake = new List<GameObject>();
    List<GameObject> BodySnake2 = new List<GameObject>();
    List<GameObject> BodySnake5 = new List<GameObject>();
    // Use this for initialization
    //napravlenie dvizhen
    public Vector2 DirectionHod;
    //rastoyanie
    float SpeedMove = 5;
    public int kolvo = 0;

    //uvilechenie ROST

    public
void AddChank()
    {
        Vector3 Position2 = transform.position;
        //if hvost est->dobavit ++
        if ((BodySnake.Count > 0) || (BodySnake.Count > 0))
        {
            //take position of hvost ->add to hvost (last elem) 
            Position2 = BodySnake[BodySnake.Count - 1].transform.position;

        }
        Position2.y += 1.5f;
        //create new block in snake (hvost) //pod uglom 0 (ident)
        GameObject Body = Instantiate(SnakeBody, Position2, Quaternion.identity) as GameObject;

        //add to hvost new block
        BodySnake.Add(Body);
    }

    public
 void AddChank5()
    {
        Vector3 Position1 = transform.position;
        //if hvost est->dobavit ++
        if ((BodySnake5.Count > 0) || (BodySnake5.Count > 0))
        {
            //take position of hvost ->add to hvost (last elem) 
            Position1 = BodySnake5[BodySnake5.Count - 1].transform.position;

        }
        Position1.y += 4;
        //create new block in snake (hvost) //pod uglom 0 (ident)
        GameObject Body5 = Instantiate(SnakeBody5, Position1, Quaternion.identity) as GameObject;

        //add to hvost new block
        BodySnake5.Add(Body5);
    }
    public void AddChank4()
    {
        Vector3 Position2 = transform.position;
        //if hvost est->dobavit ++
        if ((BodySnake2.Count > 0) || (BodySnake2.Count > 0))
        {
            //take position of hvost ->add to hvost (last elem) 
            Position2 = BodySnake2[BodySnake2.Count - 1].transform.position;

        }
        Position2.y += 4;
        //create new block in snake (hvost) //pod uglom 0 (ident)
        GameObject Body2 = Instantiate(SnakeBody2, Position2, Quaternion.identity) as GameObject;

        //add to hvost new block
        BodySnake2.Add(Body2);
    }


    void Start()
    {
        //clear lishnee iz hvosta
        BodySnake.Clear();

        //for (int i = 0; i < 3; i++)
        //AddChank();

    }



    void SnakeStap()
    {
        if ((DirectionHod.x != 0) || (DirectionHod.y != 0))
        {
            //take position of head  create varriable  ComRig
            Rigidbody ComponentRig2 = GetComponent<Rigidbody>();
            //create new osition of head  (napravlenie) if + =pravo 
            ComponentRig2.velocity = new Vector3(DirectionHod.x * SpeedMove, DirectionHod.y * SpeedMove, 0);
            if (BodySnake.Count > 0)
            {
                //change position of hvost 
                BodySnake[0].transform.position = transform.position;
                //hvost na mesto head 
                for (int BodyIndex = BodySnake.Count - 1; BodyIndex > 0; BodyIndex--)
                    BodySnake[BodyIndex].transform.position = BodySnake[BodyIndex - 1].transform.position;

            }
        }

    }

    void SnakeStap2()
    {
        if ((DirectionHod.x != 0) || (DirectionHod.y != 0))
        {
            //take position of head  create varriable  ComRig
            Rigidbody ComponentRig2 = GetComponent<Rigidbody>();
            //create new osition of head  (napravlenie) if + =pravo 
            ComponentRig2.velocity = new Vector3(DirectionHod.x * SpeedMove, DirectionHod.y * SpeedMove, 0);
            if (BodySnake2.Count > 0)
            {
                //change position of hvost 
                BodySnake2[0].transform.position = transform.position;
                //hvost na mesto head 
                for (int BodyIndex2 = BodySnake2.Count - 1; BodyIndex2 > 0; BodyIndex2--)
                    BodySnake2[BodyIndex2].transform.position = BodySnake2[BodyIndex2 - 1].transform.position;

            }
        }

    }
    void SnakeStap5()
    {
        if ((DirectionHod.x != 0) || (DirectionHod.y != 0))
        {
            //take position of head  create varriable  ComRig
            Rigidbody ComponentRig2 = GetComponent<Rigidbody>();
            //create new osition of head  (napravlenie) if + =pravo 
            ComponentRig2.velocity = new Vector3(DirectionHod.x * SpeedMove, DirectionHod.y * SpeedMove, 0);
            if (BodySnake5.Count > 0)
            {
                //change position of hvost 
                BodySnake[0].transform.position = transform.position;
                //hvost na mesto head 
                for (int BodyIndex5 = BodySnake5.Count - 1; BodyIndex5 > 0; BodyIndex5--)
                    BodySnake5[BodyIndex5].transform.position = BodySnake5[BodyIndex5 - 1].transform.position;

            }
        }

    }

    public void OlegDestroy()
    {
        //stop moving 
        DirectionHod = new Vector2(0, 0);
        foreach (GameObject o in BodySnake) DestroyObject(o.gameObject);
        //head kill
        DestroyObject(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Buff++;
        if (Buff > TimeSpeed)
        {
            SnakeStap();
            SnakeStap2(); SnakeStap5();
            Buff = 0;

        }

    }


}
