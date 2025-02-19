using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Tool_Equpping : MonoBehaviour
{
    [Header("Tool Objects")]
    [SerializeField] private GameObject eq1 ;
    [SerializeField] private GameObject eq2 ;
    [SerializeField] private GameObject eq3 ;
    private GameObject equipped;
    private Light flashlight; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        equipped = null;
        flashlight = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            equip(eq1);    
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            equip(eq2);    
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            equip(eq3);    
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (equipped != null && flashlight != null) {
                flashlight.enabled = !flashlight.enabled;
            }
        }

    }

    void equip(GameObject eq) {
        
        if (equipped != null) {
            equipped.SetActive(false);
            equipped.transform.SetParent(null);
            if (flashlight != null) {
                flashlight.enabled = false;
            }
            flashlight = null;
        }
        
        if (equipped != eq) {
                equipped = eq;
                eq.SetActive(true);
                eq.transform.SetParent(gameObject.transform);
                

                // Optional: Reset position relative to parent
                eq.transform.localPosition = new Vector3(0.4f,0,0.5f);
                eq.transform.localRotation = Quaternion.identity;
                flashlight = equipped.GetComponentInChildren<Light>();
                
            } else if (equipped == eq) {
                eq.transform.SetParent(null);
                equipped = null;
                eq.SetActive(false);
                if (flashlight != null) {
                    flashlight.enabled = false;
                }
                flashlight = null;
            }
    }

}
