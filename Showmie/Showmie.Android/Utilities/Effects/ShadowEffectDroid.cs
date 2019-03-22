using System;
using System.ComponentModel;
using System.Linq;
using Showmie.Droid.Utilities.Effects;
using Showmie.Utils.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(ShadowEffectDroid), "ShadowEffect")]
namespace Showmie.Droid.Utilities.Effects
{
    internal class ShadowEffectDroid : PlatformEffect
    {
       private float Radius { get; set; }
       private float TranslationZ { get; set; }

        protected override void OnAttached()
        {
            try
            {
                UpdateRadius();
                UpdateTranslationZ();
                UpdateControl();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot set property on attached control. Error: {ex.Message}");
            }
        }

        protected override void OnDetached()
        {
        }

        private void UpdateControl()
        {
            var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);

            if (effect == null && Container == null) return;
            Container.Elevation = Radius;
            Container.TranslationZ = TranslationZ;

            if (effect == null || Control == null) return;

            Control.Elevation = Radius;
            Control.TranslationZ = TranslationZ;
        }

        private void UpdateRadius()
        {
            Radius = (float)ShadowEffect.GetRadius(Element);
        }

        private void UpdateTranslationZ()
        {
            TranslationZ = (float)ShadowEffect.GetTranslationZ(Element);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == ShadowEffect.RadiusProperty.PropertyName)
            {
                UpdateRadius();
                UpdateControl();
            }
            else if (args.PropertyName == ShadowEffect.TranslationZProperty.PropertyName)
            {
                UpdateTranslationZ();
                UpdateControl();
            }
        }
    }
}