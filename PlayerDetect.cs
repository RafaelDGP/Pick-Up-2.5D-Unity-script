using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public Transform pos;
    private bool isLooking;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && PlayerStates.isHolding){
            PlayerStates.holdingObj.transform.position = pos.position;
            PlayerStates.holdingObj.SetActive(true);
            PlayerStates.rb.isKinematic = false;
            PlayerStates.rb = null;
            PlayerStates.holdingObj = null;
            PlayerStates.isHolding = false;
            isLooking = false;
        }

        if(Input.GetKeyDown(KeyCode.E) && isLooking && !PlayerStates.isHolding){
            PlayerStates.isHolding = true;
            PlayerStates.holdingObj.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item")){
            if(!PlayerStates.isHolding && !isLooking){
                PlayerStates.holdingObj = other.gameObject;
                PlayerStates.rb = PlayerStates.holdingObj.GetComponent<Rigidbody>();
                isLooking = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Item")){
            PlayerStates.rb = null;
            PlayerStates.holdingObj = null;
            PlayerStates.isHolding = false;
            isLooking = false;
        }
    }
}
