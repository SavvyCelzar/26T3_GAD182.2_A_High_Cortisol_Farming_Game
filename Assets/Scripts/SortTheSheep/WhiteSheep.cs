using UnityEditor;
using UnityEngine;

namespace SAE.GAD182.Project2.SortTheSheep
{ 
    public class WhiteSheep : MainSheepController
    {
        #region Unity Functions (Start and Update)
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }
        #endregion

        #region Override Functions
        protected override void AssignSceneObjects()
        {
            base.AssignSceneObjects();

            GameObject wsSortZone = GameObject.Find("WS Sort Zone");
            if (wsSortZone != null)
            {
                sortArea = wsSortZone.transform;
            }

            GameObject wsDespawner = GameObject.Find("WS Despawner");
            if (wsDespawner != null)
            {
                despawnArea = wsDespawner.transform;
            }
        }

        protected override void OnMouseDown()
        {
            base.OnMouseDown();
        }

        protected override void OnMouseDrag()
        {
            base.OnMouseDrag();
        }

        protected override void OnMouseUp()
        {
           base.OnMouseUp();
        }

        #endregion

    }
}

