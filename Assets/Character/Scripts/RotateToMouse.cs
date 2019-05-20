using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public Camera cam;
    public float maximumLength;
    public GameObject characterHand;
    public GameObject character;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;
    private Quaternion handRotation;


    // Update is called once per frame
    void Update()
    {
        doRotation();
    }

    private void doRotation()
    {
        if (cam != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;

            rayMouse = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maximumLength))
            {
                RotateToMouseDirection( gameObject, hit.point);
            }
            else
            {
                var pos = rayMouse.GetPoint(maximumLength);
                RotateToMouseDirection( gameObject, pos);
            }
        }
        else
        {
            Debug.Log("no Camera");
        }
    }

    void RotateToMouseDirection(GameObject characterPrefab, Vector3 destination)
    {         
        direction = destination - characterPrefab.transform.position;
        Vector3 handDirection = new Vector3(direction.x, direction.y, direction.z);

        rotation = Quaternion.LookRotation(direction);
        rotation.x = 0;
        rotation.z = 0;
        character.transform.localRotation = Quaternion.Lerp(character.transform.rotation, rotation, 1);

        handRotation = Quaternion.LookRotation(handDirection);
        handRotation.z = 0;
        handRotation.y = 0;
        characterHand.transform.localRotation = Quaternion.Lerp(characterHand.transform.rotation, handRotation, 1);
    }

    public Quaternion getRotation()
    {
        return Quaternion.LookRotation(direction);
    }
}
