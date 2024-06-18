using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2_script : MonoBehaviour
{
    // Start is called before the first frame update
    public float displacement;
    Rigidbody2D p2;
    Vector2 initial;
    public scoreScript score;
    public Vector3 newSize = new Vector3(0.2f, 2.5f, 1.0f);
    public Vector3 normalSize = new Vector3(0.2f, 1.5f, 1.0f);
    void Start()
    {
        p2 = GetComponent<Rigidbody2D>();
	    initial = p2.transform.localPosition;
        score = GameObject.FindGameObjectWithTag("logic").GetComponent<scoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if ((Input.GetKey(KeyCode.UpArrow) && initial.y < 3.7))
                initial.y = initial.y + displacement;
        else if ((Input.GetKey(KeyCode.DownArrow)) && initial.y > -3.7)
                initial.y = initial.y - displacement;
        
        
        if (Input.GetKey(KeyCode.RightArrow) && initial.x < 11/* Define your right boundary here */)
            initial.x = initial.x + displacement;
    
        // Check for left movement with 'A' key
        if (Input.GetKey(KeyCode.LeftArrow) && initial.x > 2/* Define your left boundary here */)
            initial.x = initial.x - displacement;


        
	

	p2.MovePosition(initial);
    }
}
