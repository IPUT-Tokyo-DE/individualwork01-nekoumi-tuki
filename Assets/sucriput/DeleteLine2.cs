using UnityEngine;

public class DeleteLine2 : MonoBehaviour
{
    LineRenderer line;
    GameObject Hoge;
    GameObject Puke;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.Hoge = GameObject.Find("GameObjectTest");
        this.Puke = GameObject.Find("GameObjectTes");

        this.line = GetComponent<LineRenderer>();

        this.line.startWidth = 0.1f;
        this.line.endWidth = 0.1f;

        this.line.positionCount = 2;

    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, Hoge.transform.position);
        line.SetPosition(1, Puke.transform.position);        
    }

    public void LInes()
    {
        

    }

    private void SetupLine()
    {


    }

}
