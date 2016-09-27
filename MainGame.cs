using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {


    int GameMode = 0;
 
    //ssilka na obj snake
    public GameObject Snake;
    public GameObject Oleg;
    // snake in game
    GameObject SnakeObj;
    GameObject OlegObj;
    float XX = 0, YY = 0;
    float XX2 = 0, YY2 = 0;
    public GameObject AutoEat;// eda
    public GameObject Eat5;// eda
    public GameObject Eat4;//poison
    public GameObject Eat3;//poison
    int TimeSpeed = 200;
    int Buff = 0;

    void AddFive()
    {
        Instantiate(Eat5);
    }


    void AddAuto()
    {
        Instantiate(AutoEat);
    }
    void AddFour()
    {
        Instantiate(Eat4);
    }

    void AddThree()
    {
        Instantiate(Eat3);
    }
    void CreateSnake1()
    {

        SnakeObj = Instantiate(Snake) as GameObject;
        SnakeObj.name = "Snake";
        //start game
        GameMode = 1;
    }
    void CreateSnake2()
    {

       OlegObj = Instantiate(Oleg) as GameObject;
        OlegObj.name = "Oleg";
        //start game
        GameMode = 2;
    }




    // Use this for initialization
    void Start () {
       // CreateSnake();
	}
	
	// Update is called once per frame
	void Update () {
        if (SnakeObj != null)
        {
            //obnulit napravlenie
            XX = 0;
            YY = 0;
         
            if (Input.GetAxis("Horizontal") > 0) XX = 1;
            if (Input.GetAxis("Horizontal") < 0) XX = -1;
            if (Input.GetAxis("Vertical") > 0) YY = 1;
            if (Input.GetAxis("Vertical") < 0) YY = -1;

            if((XX != 0) || (YY != 0))
            {
                //get component to moderete snake
                SnakeLife S = SnakeObj.GetComponent<SnakeLife>(); 
                if (XX != 0) S.DirectionHod = new Vector2(XX, 0);
                if (YY != 0) S.DirectionHod = new Vector2(0, YY);
               Oleg O = OlegObj.GetComponent<Oleg>();
                //kuda dvigatsa 
                if (XX != 0) O.DirectionHod = new Vector2(XX, 0);
                if (YY != 0) O.DirectionHod = new Vector2(0, YY);
            }
        }

       else if (OlegObj != null)
        {
            //obnulit napravlenie
            XX2 = 0;
            YY2 = 0;

            if (Input.GetAxis("Horizontal") > 0) XX2 = 1;
            if (Input.GetAxis("Horizontal") < 0) XX2 = -1;
            if (Input.GetAxis("Vertical") > 0) YY2 = 1;
            if (Input.GetAxis("Vertical") < 0) YY2 = -1;

            if ((XX2 != 0) || (YY2 != 0))
            {
                //get component to moderete snake
              
                Oleg O = OlegObj.GetComponent<Oleg>();
                //kuda dvigatsa 
                if (XX2 != 0) O.DirectionHod = new Vector2(XX2, 0);
                if (YY2 != 0) O.DirectionHod = new Vector2(0, YY2);
            }
        }


        else
        {

        
            GameMode = 0;
            
        }
        if (GameMode>0)
        {
            Buff++;
            if(Buff >TimeSpeed)//create new apple and buff==0 
            { AddFive(); AddFour(); AddThree(); AddAuto(); Buff = 0; }
        }

      


    }

    //menu
    public GUISkin MainMenu;
    void OnGUI()
    {
        GUI.skin = MainMenu;
        int posaY = Screen.height / 2;
        int posaX = Screen.width / 2;

        switch (GameMode)
        {
            case 0:
            
                GUI.Label(new Rect(new Vector2(posaX - 150, posaY-60), new Vector2(400, 60)), "<color=white><size=40>CHOOSE GAME</size></color>");
                if (GUI.Button(new Rect(new Vector2(posaX - 100, posaY), new Vector2(200, 30)), "Opahen"))  CreateSnake1();
                if (GUI.Button(new Rect(new Vector2(posaX - 100, posaY+20), new Vector2(200, 30)), "Oleg")) CreateSnake2();
                if (GUI.Button(new Rect(new Vector2(posaX - 100, posaY+ 40), new Vector2(200, 30)), "EXIT")) Application.Quit();
   
                break;

            case 1:
                //get component to mode snake
                SnakeLife S=SnakeObj.GetComponent<SnakeLife>();
                int Score = 0; int Kol = 0;        int Sr = 0;
                if (S != null) Score = S.ScoreSnake;
                //show score
       
                if (S != null) Kol = S.kolvo;
                Sr = S.ScoreSnake / S.kolvo;
                GUI.Label(new Rect(new Vector2(posaX-50, 0), new Vector2(200, 80)), "KKOl:" + Kol);
                GUI.Label(new Rect(new Vector2(posaX, 0), new Vector2(200, 30)), "Apples:" + Score);

                GUI.Label(new Rect(new Vector2(posaX - 100, 0), new Vector2(200, 80)), "SRES:" + Sr);
                break;

            case 2:
                //get component to mode snake
                Oleg O = OlegObj.GetComponent<Oleg>();
                Score = 0;  Kol = 0; Sr = 0;
                if (O != null) Score = O.ScoreOleg;
                //show score

                if (O != null) Kol = O.kolvo;
                Sr = O.ScoreOleg / O.kolvo;
                GUI.Label(new Rect(new Vector2(posaX - 50, 0), new Vector2(200, 80)), "KKOl:" + Kol);
                GUI.Label(new Rect(new Vector2(posaX, 0), new Vector2(200, 30)), "Apples:" + Score);

                GUI.Label(new Rect(new Vector2(posaX - 100, 0), new Vector2(200, 80)), "SRES:" + Sr);
                break;


        }
    }
}
