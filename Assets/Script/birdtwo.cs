using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdtwo : MonoBehaviour
{
    private bool clickedOn;

    private SpringJoint2D spring;
    private Vector2 preVelocity;

    public LineRenderer CatapultFront;
    public LineRenderer Catapultback;
    void Awake()
    {
        spring = GetComponent<SpringJoint2D>(); 
    }
    void OnMouseDown()
    {
       
        clickedOn = true;
    }

    void OnMouseUp()
    {
        clickedOn = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
       

    }
    void Update()
    {
        if (clickedOn)
            Dragging();
        if (spring != null)
        {

            if (!GetComponent<Rigidbody2D>().isKinematic && preVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude)
            {
                Destroy(spring);
                GetComponent<Rigidbody2D>().velocity = preVelocity;

            }
        }
        else
        {
            Catapultback.enabled = false;
            CatapultFront.enabled = false;
            
                }
        preVelocity = GetComponent<Rigidbody2D>().velocity;

        LineRendererUpdate();
    }

    void LineRendererUpdate()
    {
        Vector2 holdPoint = transform.position;
        CatapultFront.SetPosition(1, holdPoint);
        Catapultback.SetPosition(1, holdPoint);
    }

    void Dragging()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPoint.z = 0f;
        transform.position = mouseWorldPoint;
       
        
 
    }
    void start()
    {
        LineRendererSetup();
      
    }
    void LineRendererSetup()
    {
        CatapultFront.SetPosition(0, CatapultFront.transform.position);
        Catapultback.SetPosition(0, Catapultback.transform.position);

        CatapultFront.sortingLayerName = "Forground";
        Catapultback.sortingLayerName = "Forground";

        CatapultFront.sortingOrder = 2;
        Catapultback.sortingOrder = 0;


    }
}