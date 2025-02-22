using System;
using UnityEngine;

public class MousePainter : MonoBehaviour{
    public Camera cam;
    [Space]
    public bool mouseSingleClick;
    [Space]
    public Color paintColor;
    
    public float maxRadius = 1;

    public float minRadius = 0.3f;
    public float strength = 1;
    public float hardness = 1;
    public float maxDistance = 10.0f;
    public float minDistance = 1.0f;

    void Update(){

        bool click;
        click = mouseSingleClick ? Input.GetMouseButtonDown(0) : Input.GetMouseButton(0);

        if (click){
            Vector3 position = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f)){
                float distance = hit.distance;
                

                float radius = Math.Max((1 - Math.Max(maxDistance - distance,minDistance))/maxDistance * maxRadius,minRadius);
                

                Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red);
                transform.position = hit.point;
                Paintable p = hit.collider.GetComponent<Paintable>();
                if(p != null){
                    PaintManager.instance.paint(p, hit.point, radius, hardness, strength, paintColor);
                }
            }
        }

    }

}
