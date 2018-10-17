using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Showmie.Views;
using Showmie.Droid.Renderers;
using Xamarin.Forms;
using View = Android.Views.View;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CardHolder), typeof(CardHolderRenderer))]
namespace Showmie.Droid.Renderers
{
    class CardHolderRenderer : ViewRenderer<Grid, View>
    {
        private readonly Context ctx;
        private CardHolder _cardHolder;
        private View _androidGrid;

        public CardHolderRenderer(Context context) : base(context)
        {
            ctx = context;
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Grid> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
                _cardHolder = e.OldElement as CardHolder;
            if (e.NewElement != null)
                _cardHolder = e.NewElement as CardHolder;
            if (Element != null)
                _cardHolder = Element as CardHolder;
            
            //if (Control != null)
            //{
            //    _androidGrid = Control;
            //}
            //else
            //{
            //    _androidGrid = CreateNativeControl();
            //    SetNativeControl(_androidGrid);
            //}
            _cardHolder.HeightRequest = _cardHolder.PostImage.Height; 
        }
    }
}