using UnityEngine;

namespace SAE.GAD182.Project2.SortTheSheep
{
    public class BlackRam : MainSheepController
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

            GameObject brSortZone = GameObject.Find("BR Sort Zone");
            if (brSortZone != null)
            {
                sortArea = brSortZone.transform;
            }

            GameObject brDespawner = GameObject.Find("BR Despawner");
            if (brDespawner != null)
            {
                despawnArea = brDespawner.transform;
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

