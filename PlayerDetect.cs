using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public Transform pos;
    private bool isHolding;
    private bool isLooking;
    private GameObject obj;
    private Rigidbody rb;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && isHolding){
            Debug.Log("Soltou");
            rb.isKinematic = false;
            obj = null;
            rb = null;
            isHolding = false;
            isLooking = false;
        }

        if(Input.GetKeyDown(KeyCode.E) && isLooking && !isHolding){
            isHolding = true;
        }

        if(isHolding && obj != null){
            obj.transform.position = pos.position;
            rb.isKinematic = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item")){
            if(!isHolding && !isLooking){
                Debug.Log("Pegou");
                obj = other.gameObject;
                rb = obj.GetComponent<Rigidbody>();
                isLooking = true;
            }
        }
    }
}
