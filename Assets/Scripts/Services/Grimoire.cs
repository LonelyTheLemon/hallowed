using UnityEngine;

namespace Grimoire {
    public static class Voodoo {
        public static void Show(this CanvasGroup canvasGroup) {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }

        public static void Hide(this CanvasGroup canvasGroup) {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        }
    }
}