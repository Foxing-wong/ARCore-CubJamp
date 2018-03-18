using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    //方体
    public GameObject cube;

	// Update is called once per frame
	void Update () {

        foreach (var touch in Input.touches)
        {
            Shot(touch.position);
            if (Input.touchCount > 1 && touch.phase == TouchPhase.Began)
                addCude();
        }
	}
    
    //创建方体
    void addCude()
    {
        GameObject.Instantiate(cube, transform.position + transform.forward * 0.3f, Random.rotation);
    }

    //旋转
    void Shot(Vector2 screenPoint)
    {
        var ray = Camera.main.ScreenPointToRay(screenPoint);
        var hitInfo = new RaycastHit();
        if(Physics.Raycast(ray,out hitInfo))
        {
            hitInfo.rigidbody.AddForceAtPosition(ray.direction, hitInfo.point);
        }
    }


}
