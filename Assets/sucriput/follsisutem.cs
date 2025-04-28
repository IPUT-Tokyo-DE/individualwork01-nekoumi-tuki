
using UnityEngine;

public class follsisutem : MonoBehaviour
{
    private float time;
    private float vecX;

    private GameObject droper;
    private int originObject;
    public GameObject[] Prefabe; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void InstP()
    {
        originObject = Random.Range(0, Prefabe.Length);
        Instantiate(Prefabe[originObject], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time<=0)
        {
            vecX = Random.Range(-4f, 4f);
           

            this.transform.position = new Vector3(vecX, 5f);

            InstP();

            time = 1.0f;

        }
    }
}
