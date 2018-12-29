using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Showmie.Droid.Renderers;
using Showmie.Models;
using Showmie.Views;
using Showmie.Views.CustomViews;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Widget.GridLayout;
using Application = Xamarin.Forms.Application;
using Color = Xamarin.Forms.Color;
using static Showmie.Models.FilterItem.ExploreTitles;

[assembly: ExportRenderer(typeof(CoordinatorPage), typeof(CoordinatorPageRenderer))]
namespace Showmie.Droid.Renderers
{
    internal class CoordinatorPageRenderer : ViewRenderer<CoordinatorPage, CoordinatorLayout>
    {
        private CoordinatorPage _XamCoordinator;
        private readonly CoordinatorLayout _androidCoordinatorLayout;
        private GridLayout gridLayout;

        private static Color checkedColor { get; set; } = (Color)Application.Current.Resources["CheckedCheckboxBackgroundColor"];
        public static Color uncheckedColor { get; set; } = (Color)Application.Current.Resources["UnCheckedCheckboxBackgroundColor"];

        public ObservableCollection<FilterItem> FilterItems { get; set; } = new ObservableCollection<FilterItem>() {
                new FilterItem(false, Accessories, checkedColor, uncheckedColor),
                new FilterItem(false, Model, checkedColor, uncheckedColor),
                new FilterItem(false, MakeUp, checkedColor, uncheckedColor),
                new FilterItem(false, HairStyles, checkedColor, uncheckedColor),
                new FilterItem(false, Jewelry, checkedColor, uncheckedColor),
                new FilterItem(false, Photography, checkedColor, uncheckedColor),
                new FilterItem(false, OutfitDesigns, checkedColor, uncheckedColor),
                new FilterItem(false, FashionBlogs, checkedColor, uncheckedColor)
            };


        public CoordinatorPageRenderer(Context context) : base(context)
        {
            _androidCoordinatorLayout = new CoordinatorLayout(context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CoordinatorPage> e)
        {
            base.OnElementChanged(e);
            #region Element Setup
            if (e.OldElement != null)
            {
                _XamCoordinator = e.OldElement as CoordinatorPage;
                _XamCoordinator.ShowFilters -= HandleShowFilters;
            }

            if (e.NewElement != null)
            {
                _XamCoordinator = e.NewElement as CoordinatorPage;
                _XamCoordinator.ShowFilters += HandleShowFilters;
            }

            if (Element != null)
            {
                _XamCoordinator = Element as CoordinatorPage;
            }

            if (Control == null)
            {
                SetNativeControl(_androidCoordinatorLayout);
            }
            #endregion

            gridLayout = new GridLayout(Context)
            {
                LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent, 1f),
                RowCount = 4,
                ColumnCount = 2,
            };
            gridLayout.SetPadding(18, 12, 18, 12);

            int rowIndex = 0;
            LinearLayout linearLayoutOne = new LinearLayout(Context)
            {
                Orientation = Android.Widget.Orientation.Vertical
            };

            LinearLayout linearLayoutTwo = new LinearLayout(Context)
            {
                Orientation = Android.Widget.Orientation.Vertical
            };
            
            foreach (FilterItem item in FilterItems)
            {
                CheckBox _androidCheckBox = new CheckBox(Context)
                {
                    Checked = item.IsChecked,
                    Text = item.Title
                };
                int[][] states = new int[][] {
                    new int[] { Android.Resource.Attribute.StateChecked}, // enabled
                    new int[] { Android.Resource.Attribute.StateEnabled}// pressed
                };

                int[] colors = new int[] {
                    item.CheckedBackgroundColor.ToAndroid(),
                    item.UnCheckedBackgroundColor.ToAndroid()
                };
                _androidCheckBox.ButtonTintList = new ColorStateList(states, colors);
                if (rowIndex <= 3)
                {
                    linearLayoutOne.AddView(_androidCheckBox, new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent));
                    rowIndex++;
                }
                else if (rowIndex > 3)
                {
                    //Spec rowSpec = InvokeSpec(rowIndex - 4, Center);
                    //Spec colSpec = InvokeSpec(1, Start);
                    //GridLayout.AddView(_androidCheckBox, new GridLayout.LayoutParams(rowSpec, colSpec));
                    linearLayoutTwo.AddView(_androidCheckBox, new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent));
                    rowIndex++;
                }
            }

            Spec rowSpecOne = InvokeSpec(1, Center);
            Spec colSpecOne = InvokeSpec(0, Center, 1f);
            gridLayout.AddView(linearLayoutOne, new GridLayout.LayoutParams(rowSpecOne, colSpecOne));
            Spec rowSpecTwo = InvokeSpec(1, Center);
            Spec colSpecTwo = InvokeSpec(1, Center, 1f);
            gridLayout.AddView(linearLayoutTwo, new GridLayout.LayoutParams(rowSpecTwo, colSpecTwo));
            //(_androidCoordinatorLayout).AddView(GridLayout);
            DisplayMetrics metrics = Context.Resources.DisplayMetrics;
            int H = metrics.HeightPixels;
        //CoordinatorLayout.LayoutParams parameters = (CoordinatorLayout.LayoutParams)GridLayout.LayoutParameters;

        //BottomSheetBehavior bottomSheetBehavior = new BottomSheetBehavior
        //{
        //    PeekHeight = 200,
        //    Hideable = false,

        //};
        //parameters.Behavior = bottomSheetBehavior;
        //GridLayout.RequestLayout();
        //_androidCoordinatorLayout.SetBackgroundColor(Android.Graphics.Color.Green);
    }

        private void HandleShowFilters(object sender, EventArgs e)
        {
            FragmentActivity activity = Context as FragmentActivity;
            ExploreBottomFragment bottomSheetDialogFragment = new ExploreBottomFragment(gridLayout);
            bottomSheetDialogFragment.Show(activity.SupportFragmentManager, bottomSheetDialogFragment.Tag);
        }
    }
    public class ExploreBottomFragment : BottomSheetDialogFragment
    {
        private GridLayout gridLayout;

        public ExploreBottomFragment(GridLayout gridLayout)
        {
            this.gridLayout = gridLayout ?? throw new System.ArgumentNullException(nameof(gridLayout));
        }

        public override void SetupDialog(Dialog dialog, int style)
        {
            base.SetupDialog(dialog, style);
            gridLayout.RemoveFromParent();
            dialog.SetContentView(gridLayout);
        }
    }


}