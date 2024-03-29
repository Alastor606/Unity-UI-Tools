#if UNITY_EDITOR
namespace UIHelper
{
    using UnityEngine;
    using UnityEditor;
    using UnityEngine.UI;
    using Unity.VisualScripting;
    using TMPro;

    public static class GradientCommans
    {

        [MenuItem("GameObject/UI Helper/Functions/Random Gradient/Horizontal #2",false, 3)]
        public static void GenerateRandomGradient()
        {
            var obj = Selection.activeGameObject;
            if(obj.TryGetComponent(out Image img))
            {
                var texture = GradientCreator.Horizontal((int)img.rectTransform.rect.width, (int)img.rectTransform.rect.height, Random.ColorHSV(), Random.ColorHSV());
                img.sprite = Sprite.Create(texture, new Rect(0, 0, (int)img.rectTransform.rect.width, (int)img.rectTransform.rect.height), new Vector2(0.5f, 0.5f));
            }
            else if (obj.TryGetComponent(out TMP_Text tmp)) GradientCreator.Text(true, tmp, Random.ColorHSV(), Random.ColorHSV());
            
            
        }

        [MenuItem("GameObject/UI Helper/Functions/Random Gradient/Vertical #1", false, 3)] 
        public static void GenerateRandomVerticalGradient()
        {
            var obj = Selection.activeGameObject;
            if (obj.TryGetComponent(out Image img))
            {
                var texture = GradientCreator.Vertical((int)img.rectTransform.rect.width, (int)img.rectTransform.rect.height, Random.ColorHSV(), Random.ColorHSV());
                img.sprite = Sprite.Create(texture, new Rect(0, 0, (int)img.rectTransform.rect.width, (int)img.rectTransform.rect.height), new Vector2(0.5f, 0.5f));
            }
            else if (obj.TryGetComponent(out TMP_Text tmp)) GradientCreator.Text(false, tmp, Random.ColorHSV(), Random.ColorHSV());
        }

        [MenuItem("GameObject/UI Helper/Functions/Random Gradient/Radial #3", false, 4)]
        public static void RandomRadial()
        {
            var obj = Selection.activeGameObject;
            if (!obj.TryGetComponent(out Image img)) return;
            var texture = GradientCreator.Radial((int)img.rectTransform.rect.width, (int)img.rectTransform.rect.height, Random.ColorHSV(), Random.ColorHSV());
            img.sprite = Sprite.Create(texture, new Rect(0, 0, (int)img.rectTransform.rect.width, (int)img.rectTransform.rect.height), new Vector2(0.5f, 0.5f));
        }

        [MenuItem("GameObject/UI Helper/Functions/Reverse Texture/Horizontal %w")]
        public static void ReverseTexture()
        {
            var img = Selection.activeGameObject.GetComponent<Image>();
            Texture2D texture = img.sprite.texture;

            for (int y = 0; y < texture.height; y++)
            {
                for (int x = 0; x < texture.width / 2; x++)
                {
                    Color tempColor = texture.GetPixel(x, y);
                    texture.SetPixel(x, y, texture.GetPixel(texture.width - 1 - x, y));
                    texture.SetPixel(texture.width - 1 - x, y, tempColor);
                }
            }
            texture.Apply(); 
        }

        [MenuItem("GameObject/UI Helper/Functions/Reverse Texture/Vertical %e")]

        public static void ReverseVertical()
        {
            var img = Selection.activeGameObject.GetComponent<Image>();
            Texture2D texture = img.sprite.texture;

            for (int x = 0; x < texture.width; x++)
            {
                for (int y = 0; y < texture.height / 2; y++)
                {
                    Color tempColor = texture.GetPixel(x, y); 
                    texture.SetPixel(x, y, texture.GetPixel(x, texture.height - 1 - y));
                    texture.SetPixel(x, texture.height - 1 - y, tempColor);
                }
            }
            texture.Apply();
        }


        [MenuItem("GameObject/UI Helper/Functions/Random Gradient",true)]
        public static bool CheckSelected() =>
            Selection.activeObject.GetComponent<Image>() != null;
        
    }
}

#endif