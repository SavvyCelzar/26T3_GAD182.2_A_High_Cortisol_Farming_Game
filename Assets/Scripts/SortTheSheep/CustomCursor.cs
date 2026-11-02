using UnityEngine;
using UnityEngine.InputSystem;

namespace SAE.GAD182.Project2.SortTheSheep
{
    /// <summary>   
    /// This script tracks a custom sprite image to the cursor with intent of stylising the cursor visuals appropriately with the game's visual style.
    /// </summary>
    public class CustomCursor : MonoBehaviour
    {
        #region Cursor Code

        private void Update()
        {
            Cursor.visible = false;

            Vector3 mousePosition;

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            transform.position = mousePosition;

        }

        #endregion
    }
}

