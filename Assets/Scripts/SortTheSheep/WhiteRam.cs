using UnityEngine;

namespace SAE.GAD182.Project2.SortTheSheep
{
    public class WhiteRam : MainSheepController
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
           
            GameObject wrSortZone = GameObject.Find("WR Sort Zone");
            if (wrSortZone != null)
            {
                sortArea = wrSortZone.transform;
            }

            GameObject wrDespawner = GameObject.Find("WR Despawner");
            if (wrDespawner != null)
            {
                despawnArea = wrDespawner.transform;
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
