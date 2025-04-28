using UnityEngine;

public class follar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public float Follspeed;
    private bool Tach = false;
    

    public void OncllisionEnter(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("container")||collision.gameObject.CompareTag("FollObject") || collision.gameObject.CompareTag("FollObjectCri") || collision.gameObject.CompareTag("FollObjectTri"))
        {
            Tach = true;
            
        }
    }

    public void Foll()
    {
        Vector3 pos = transform.position;
        pos.y -= Follspeed;
        transform.position = pos;



    }
    // Update is called once per frame
    void Update()
    {
        if(Tach == false)
            Foll();

    }
    

}
