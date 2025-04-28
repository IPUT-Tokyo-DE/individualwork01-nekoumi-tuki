using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DeleteLine : MonoBehaviour
{
    GameObject clickedGameObject;
    GameObject clickedGameObject2;
    GameObject clickedGameObject3;
    GameObject clickedGameObject4;

    GameObject[] CirObj;

    GameObject scoreText;

    LineRenderer line;

  
    GameObject Fast;
    GameObject Second;
    GameObject Third;
    GameObject Fourth;

    private int LineStack = 0;
  
    private int ScoreAdditinValue = 100;
    private bool AutClicker = false;
    private GameObject ChackObj;

    [SerializeField] private GameObject _gauge;
    [SerializeField] private GameObject _grecegauge;
    [SerializeField] private int _HP;
    private float _HP1;
    private float _waitingTime = 0.5f;
    private float stop;
    private int count;
    private int _HPcount;

    private int Circount;


    void Awake()
    {
        _HP1 = _gauge.GetComponent<RectTransform>().sizeDelta.y/_HP;

        BeInjured(-_HP);
        count = 0;
        _HPcount = _HP;
        Vector2 scale = transform.localScale;
        scale.y = 0;
        transform.localScale = scale;
    }

    private void BeInjured(int point)
    {
        
        float damage = 0;

        if (count + point <= _HPcount)
        {
            count += point;
            UnityEngine.Debug.Log(count);

            damage = _HP1 * point;

            StartCoroutine(PointEm(damage));
        }
        if(count + point > _HPcount)
        {
            count += point;
            point -= count - _HP;
          
            UnityEngine.Debug.Log(count);

            damage = _HP1 * point;
            StartCoroutine(PointEm(damage));
        }
    }

    IEnumerator PointEm(float damage)
    {
        Vector2 nowsafes = _gauge.GetComponent<RectTransform>().sizeDelta;
        nowsafes.y += damage;

        _gauge.GetComponent<RectTransform>().sizeDelta = nowsafes;


        yield return new WaitForSeconds(_waitingTime);

        _grecegauge.GetComponent<RectTransform>().sizeDelta = nowsafes;
 
    }

    

    private void Gauge(float scaleValue)
    {
        Vector2 scale = transform.localScale;
        scale.y = scaleValue;
        transform.localScale = scale;
    }

    void Start()
    {


        scoreText = GameObject.Find("scoreText");

    }

    public void ReseterButton()
    {
        LineStack -= 1;
        LineStack = 0;
        clickedGameObject = null;
        clickedGameObject2 = null;
        clickedGameObject3 = null;
        clickedGameObject4 = null;
        //this.line.positionCount = 0;
        AutClicker = false;

        ScoreAdditinValue = 100;
    }


    // Update is called once per frame
    void Update()
    { 

        ChackColors();
        backer();
        
        LineAut();

        MaruD();
        //クッリクによりオブジェクトを選択する
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            LineStack += 1;
            


            if (LineStack == 1)
            {
                //選択したオブジェクトを変数に入れる
                if (hit2d)
                {
                    clickedGameObject = hit2d.transform.gameObject;
                    //UnityEngine.Debug.Log("1");
                    
                }
            }

            if (LineStack == 2)
            {
                //選択したオブジェクトを変数に入れる
                if (hit2d)
                {
                    clickedGameObject2 = hit2d.transform.gameObject;
                    //UnityEngine.Debug.Log("2");

                }
            }

            if (LineStack == 3)
            {
                //選択したオブジェクトを変数に入れる
                if (hit2d)
                {
                    clickedGameObject3 = hit2d.transform.gameObject;
                   // UnityEngine.Debug.Log("3");
                }
            }

            if (LineStack == 4)
            {
                //選択したオブジェクトを変数に入れる
                if (hit2d)
                {
                    clickedGameObject4 = hit2d.transform.gameObject;
                    //UnityEngine.Debug.Log("4");
                   
                }
            }

            this.Fast = clickedGameObject;
            this.Second = clickedGameObject2;
            this.Third = clickedGameObject3;
            this.Fourth = clickedGameObject4;


        }
        
        
        AutClick();

        if (AutClicker == true)
        {
            if (LineStack >= 3)
            {

                if (clickedGameObject != null && clickedGameObject.CompareTag("FollObjectTri"))
                {
                    Lineset();

                }
            }


            if (LineStack >= 4)
            {

                if (clickedGameObject.CompareTag("FollObject"))
                {
                    LineSet();

                }
            }


        }
        

    }

    private void backer()
    {
        if (LineStack == 1)
        {
            if (clickedGameObject == null)
            {
                LineStack -= 1;
                clickedGameObject = null;
                // UnityEngine.Debug.Log("Aut");
            }
        }  
        if (LineStack == 2)
        {
            if (clickedGameObject2 == null)
            {
                LineStack -= 1;
                clickedGameObject2 = null;
               // UnityEngine.Debug.Log("Aut");
            }
        }
        if (LineStack == 3)
        {
            if (clickedGameObject3 == null)
            {
                LineStack -= 1;
                clickedGameObject3 = null;
                //UnityEngine.Debug.Log("Aut");
            }
        }
        if (LineStack == 4)
        {
            if (clickedGameObject4 == null)
            {
                LineStack -= 1;
                clickedGameObject4 = null;
                //UnityEngine.Debug.Log("Aut");
            }
        }
        

    }



    private void ChackColors()
    {


        if(clickedGameObject == null)
        {
            SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();
            // マテリアルの色設定に赤色を設定
            renderer.color = Color.black;
            //this.obj.GetComponent<Renderer>().material.color = Color.red;
            Vector2 scale = transform.localScale;
            scale.y = 0;
            transform.localScale = scale;
        }

        if (clickedGameObject != null && clickedGameObject.CompareTag("FollObject"))
        {
           
            SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();
            // マテリアルの色設定に赤色を設定
            renderer.color = Color.cyan;
            //this.obj.GetComponent<Renderer>().material.color = Color.red;
            if(LineStack ==1)
            {
                Gauge(0.25f);
            }
            if (LineStack == 2)
            {
                Gauge(0.5f);
            }
            if (LineStack == 3)
            {
                Gauge(0.75f);
            }
            if (LineStack == 4)
            {
                Gauge(1);
            }
        }
        if (clickedGameObject != null && clickedGameObject.CompareTag("FollObjectTri"))
        {
            
            SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();
            // マテリアルの色設定に赤色を設定
            renderer.color = Color.magenta;
            //this.obj.GetComponent<Renderer>().material.color = Color.red;
            if (LineStack == 1)
            {
                Gauge(0.33f);
            }
            if (LineStack == 2)
            {
                Gauge(0.66f);
            }
            if (LineStack == 3)
            {
                Gauge(1f);
            }
        }
        
    }
    private void LineAut()
    {
        if (LineStack >= 2)
        {
            if (clickedGameObject2 != null && clickedGameObject.tag != clickedGameObject2.tag)
            {
                Reseter();
                //UnityEngine.Debug.Log("AUT");
            }
        }

        if (LineStack >= 3)
        {
            if (clickedGameObject3 != null && clickedGameObject2.tag != clickedGameObject3.tag || clickedGameObject.tag != clickedGameObject3.tag!)
            {
                Reseter();
                //UnityEngine.Debug.Log("AUT");
            }
        }

        if (LineStack >= 4)
        {
            if (clickedGameObject4 != null && clickedGameObject3.tag != clickedGameObject4.tag || clickedGameObject2.tag != clickedGameObject4.tag || clickedGameObject.tag != clickedGameObject4.tag!)
            {
                Reseter();
                //UnityEngine.Debug.Log("AUT");
            }
        }
        
    }

    private void AutClick()
    {


        if (clickedGameObject != null && clickedGameObject == clickedGameObject2)
        {
            Reseter();

        }
        if (clickedGameObject != null && clickedGameObject == clickedGameObject3)
        {
            Reseter();
            //UnityEngine.Debug.Log("AUT");
        }

        if (clickedGameObject != null && clickedGameObject == clickedGameObject4)
        {
            Reseter();
        }

        if (clickedGameObject2 != null && clickedGameObject2 == clickedGameObject3)
        {
            Reseter();
        }

        if (clickedGameObject2 != null && clickedGameObject2 == clickedGameObject4)
        {
            Reseter();
        }

        if (clickedGameObject3 != null && clickedGameObject3 == clickedGameObject4)
        {
            Reseter();
        }
        else
        {
            AutClicker = true;
        }

    }

    public void MaruD()
    {
        if(count >= _HP)
        {
            BeInjured(-_HP);
            count = 0;

            UnityEngine.Debug.Log("iaa");
            CirObj = GameObject.FindGameObjectsWithTag("FollObjectCri");
            Circount = CirObj.Length;
            foreach (GameObject obj in CirObj)
            {
                Scoreprs();
                Destroy(obj);
            }

        }
    }
    public void Lineset()
    {
        
        //Lineの頂点となるオブジェクトの指定
        if (clickedGameObject !=null&& clickedGameObject3 !=null&& clickedGameObject.CompareTag("FollObjectTri") && clickedGameObject2.CompareTag("FollObjectTri") && clickedGameObject3.CompareTag("FollObjectTri"))
        {
            this.line = GetComponent<LineRenderer>();
            this.line.material = new Material(Shader.Find("Sprites/Default"));
            this.line.startColor = Color.black;
            this.line.endColor = Color.black;
            this.line.loop = true;
            this.line.startWidth = 0.1f;
            this.line.endWidth = 0.1f;
            this.line.positionCount = 3;

            line.SetPosition(0, Fast.transform.position);
            line.SetPosition(1, Second.transform.position);
            line.SetPosition(2, Third.transform.position);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                FollerDestroyTri();
                
            }


        }
 

    }



    public void LineSet()
    { 
        //Lineの頂点となるオブジェクトの指定
        if (clickedGameObject != null&& clickedGameObject4 != null && clickedGameObject.CompareTag("FollObject")&& clickedGameObject2.CompareTag("FollObject") && clickedGameObject3.CompareTag("FollObject")&&clickedGameObject4.CompareTag("FollObject"))
        {
            this.line = GetComponent<LineRenderer>();
            this.line.material = new Material(Shader.Find("Sprites/Default"));
            this.line.startColor = Color.black;
            this.line.endColor = Color.black;
            this.line.loop = true;
            this.line.startWidth = 0.1f;
            this.line.endWidth = 0.1f;
            this.line.positionCount = 4;

            line.SetPosition(0, Fast.transform.position);
            line.SetPosition(1, Second.transform.position);
            line.SetPosition(2, Third.transform.position);
            line.SetPosition(3, Fourth.transform.position);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                FollerDestroy();
               
            }


            

        }

    }

   
 
    

    private void Reseter()
    {
        LineStack = 0;
        clickedGameObject = null;
        clickedGameObject2 = null;
        clickedGameObject3 = null;
        clickedGameObject4 = null;
        //this.line.positionCount = 0;
        AutClicker = false;
        
        ScoreAdditinValue = 100;
    }



    private void FollerDestroyTri()
    {
        LineStack = 0;
        Destroy(clickedGameObject);
        Destroy(clickedGameObject2);
        Destroy(clickedGameObject3);
        this.line.positionCount = 0;

        Scoreprs();
        BeInjured(3);
        ScoreAdditinValue += 5;
    }

    private void FollerDestroy()
    {
        LineStack = 0;
        Destroy(clickedGameObject);
        Destroy(clickedGameObject2);
        Destroy(clickedGameObject3);
        Destroy(clickedGameObject4);
        this.line.positionCount = 0;

        Scoreprs();
        BeInjured(4);
        ScoreAdditinValue += 5;
    }

    private void Scoreprs()
    {
        scoreText.GetComponent<ScoreSistem>().score += ScoreAdditinValue;
    }

}
    
  


