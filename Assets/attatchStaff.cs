using UnityEngine;

public class attatchStaff : MonoBehaviour
{
    public GameObject staffPrefab;
    public Transform handTransform;

    void Start()
    {
        // GameObject staff = Instantiate(staffPrefab, handTransform.position, handTransform.rotation);        // Make the wand a child of the hand
        // staff.transform.SetParent(handTransform);
        
        // // Now set the local position of the wand to match the hand's local position, 
        // // which in this case will be (0,0,0) because we're aligning it directly
        // staff.transform.localPosition = Vector3.zero;
    }
}
