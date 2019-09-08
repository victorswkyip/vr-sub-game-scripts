using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VRPlatformManager : MonoBehaviour {

    //Both Google Cardboard and GearVR have specific settings they need to have in order to be built properly. 
    //If building for both platforms, manually switching these settings each time can be time consuming, so these menu options automate it

    [MenuItem("VR Platforms/Setup Build for GearVR")]
    static void BuildForGear() {
        ToggleActivePlatformObjects("GoogleVR", false);
        PlayerSettings.virtualRealitySupported = true;
        PlayerSettings.productName = "MobileVRTraining For GearVR";
        PlayerSettings.applicationIdentifier = "com.Circuit.GearVRTraining";
        Texture2D icon = Resources.Load("GearVR") as Texture2D;
        Debug.Log(icon.name);
        Texture2D[] icons = new Texture2D[] { icon, icon, icon, icon, icon, icon };
        PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Android, icons);
    }

    [MenuItem("VR Platforms/Setup Build for Cardboard")]
    static void BuildForCardboard() {
        ToggleActivePlatformObjects("GoogleVR", true);
        PlayerSettings.virtualRealitySupported = false;
        PlayerSettings.productName = "MobileVRTraining For GoogleVR";
        PlayerSettings.applicationIdentifier = "com.Circuit.GoogleVRTraining";
        Texture2D icon = Resources.Load("GoogleCardboard") as Texture2D;
        Debug.Log(icon.name);
        Texture2D[] icons = new Texture2D[] { icon, icon, icon, icon, icon, icon };
        PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Android, icons);
    }

    static void ToggleActivePlatformObjects(string parentObjectName, bool active) {
        Transform parent = GameObject.Find(parentObjectName).transform;
        foreach (Transform child in parent) {
            child.gameObject.SetActive(active);
        }
    }
}
