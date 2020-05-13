using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace HELI
{
    public class HelicopterMenu
    {
        [MenuItem("Vaziri/Vehicles/Set Up New Helicopter")]
        public static void BuildNewHelicopter()
        {
            //create new helicopter setup game object
            GameObject curHeli = new GameObject("NewHeli", typeof(HeliController));

            //create the cog object for the helicopter
            GameObject curCOG = new GameObject("COG");
            curCOG.transform.SetParent(curHeli.transform);

            //assign the cog to curHeli
            HeliController curController = curHeli.GetComponent<HeliController>();
            curController.centerOfGravity = curCOG.transform;

            //create subgroups
            GameObject audioGRP = new GameObject("Audio_GRP");
            GameObject graficsGRP = new GameObject("Grafics_GRP");
            GameObject colGRP = new GameObject("COllision_GRP");

            audioGRP.transform.SetParent(curHeli.transform);
            graficsGRP.transform.SetParent(curHeli.transform);
            colGRP.transform.SetParent(curHeli.transform);
            Selection.activeGameObject = curHeli;
        }
    }
}
