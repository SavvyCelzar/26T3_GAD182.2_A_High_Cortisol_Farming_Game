using UnityEngine;

namespace SAE.GAD182.Project2.SortTheSheep
{
    public class BlackSheep : MainSheepController
    {
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

        protected override void AssignSceneObjects()
        {
            base.AssignSceneObjects();
            
            GameObject bsSortZone = GameObject.Find("BS Sort Zone");
            if (bsSortZone != null)
            {
                sortArea = bsSortZone.transform;
            }

            GameObject bsDespawner = GameObject.Find("BS Despawner");
            if (bsDespawner != null)
            {
                despawnArea = bsDespawner.transform;
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
    }
}

