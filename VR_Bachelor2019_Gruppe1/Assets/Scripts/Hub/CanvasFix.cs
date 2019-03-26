/* Retrieved from https://answers.unity.com/questions/1437486/vrtk-ui-doesnt-work-after-load-scene.html
 * When Hub scene(index 0) is reloded there was a problem related to 
 * the Unity EventSystem being disabled and not working properly.
 * 
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
        Debug.Log("fix started");
        StartCoroutine(LateStart(1));
    }

    private void Update()
    {
        if (inputModule != null)
        {
            if (inputModule.Length > 0)
            {
                //Debug.Log("inputModule.Length > 0: " + (inputModule.Length > 0));
                inputModule[0].enabled = true;
                //Debug.Log(inputModule[0].pointers.Count == 0);
                if (inputModule[0].pointers.Count == 0) { 
                    inputModule[0].pointers.Add(PointerController[0]);
                    inputModule[0].pointers.Add(PointerController[1]);
                    Debug.Log("fix added");
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