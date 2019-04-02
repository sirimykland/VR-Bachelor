/* CanvasFix.cs - 02.04.2019
 * Retrieved from https://answers.unity.com/questions/1437486/vrtk-ui-doesnt-work-after-load-scene.html
 * When a Scene is reloded the System has a problem related to 
 * the Unity EventSystem being disabled and not working properly.
 * The CanvasFix class adds the controllers as inputmodules.
 */

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using VRTK;

public class CanvasFix : MonoBehaviour
{
    public GameObject EventSystem;
    public VRTK_UIPointer[] PointerController;

    private VRTK_VRInputModule[] inputModule;

    private void Start()
    {
        StartCoroutine(LateStart(1));
    }

    private void Update()
    {
        if (inputModule != null)
        {
            if (inputModule.Length > 0)
            {
                inputModule[0].enabled = true;
                
                if (inputModule[0].pointers.Count == 0) { 
                    inputModule[0].pointers.Add(PointerController[0]);
                    inputModule[0].pointers.Add(PointerController[1]);
                }
            }
            else
                inputModule = EventSystem.GetComponents<VRTK_VRInputModule>();
        }
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        EventSystem.SetActive(true);
        EventSystem.GetComponent<EventSystem>().enabled = false;
        inputModule = EventSystem.GetComponents<VRTK_VRInputModule>();
    }
}