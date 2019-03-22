using System;
using Xamarin.Forms;
using static Showmie.Models.User;

namespace Showmie.Views
{
    public class SwitchButton : Grid
    {

        public SwitchButton()
        {
            ColumnDefinitions = new ColumnDefinitionCollection()
            {
                new ColumnDefinition(){Width = new GridLength (1, GridUnitType.Star) },
                new ColumnDefinition(){Width = new GridLength (1, GridUnitType.Star) }
            };

            Padding = 2;
            BackgroundColor = (Color)Application.Current.Resources["TextColorNearBlack"];

            LeftLabel = new Label()
            {
                WidthRequest = -1,
                Text = LeftText,
                LineBreakMode = LineBreakMode.NoWrap,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = (Color)Application.Current.Resources["TextColorNearBlack"],
                FontSize = (double)Application.Current.Resources["FontSizeMedium"],
                FontFamily = (OnPlatform<string>)Application.Current.Resources["QuicksandMedium"]
            };

            RightLabel = new Label()
            {
                WidthRequest = -1,
                Text = RightText,
                LineBreakMode = LineBreakMode.NoWrap,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = (Color)Application.Current.Resources["TextColorNearBlack"],
                FontSize = (double)Application.Current.Resources["FontSizeMedium"],
                FontFamily = (OnPlatform<string>)Application.Current.Resources["QuicksandMedium"]
            };

            LeftBoxView = new BoxView() { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill };
            RightBoxView = new BoxView() { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill };

            Children.Add(LeftBoxView, 0, 0);
            Children.Add(LeftLabel, 0, 0);
            Children.Add(RightBoxView, 1, 0);
            Children.Add(RightLabel, 1, 0);
        }

        private Label LeftLabel { get; set; }
        private Label RightLabel { get; set; }
        private BoxView LeftBoxView { get; set; }
        private BoxView RightBoxView { get; set; }

        private static class SwitchPositions {
            public static string Left { get; set; } = "Left";
            public static string Right { get; set; } = "Right";
        }
       
        public string SwitchPosition {
            get { return (string)GetValue(SwitchPositionProperty); }
            set { SetValue(SwitchPositionProperty, value); }
        }

        public static BindableProperty SwitchPositionProperty { get; } = BindableProperty.Create(
            "SwicthPosition",
            typeof(string),
            typeof(SwitchButton),
            "Left",
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                if (!newvalue.Equals(oldvalue))
                {
                    if (newvalue as string == "Left")
                    {
                        ((SwitchButton)bindable).LeftBoxView.BackgroundColor = (Color)Application.Current.Resources["TextColorNearBlack"];
                        ((SwitchButton)bindable).LeftLabel.TextColor = Color.White;

                        ((SwitchButton)bindable).RightLabel.TextColor = (Color)Application.Current.Resources["TextColorLightBlack"];
                        ((SwitchButton)bindable).RightBoxView.BackgroundColor = Color.White;
                    }
                    else if (newvalue as string == "Right")
                    {
                        ((SwitchButton)bindable).LeftBoxView.BackgroundColor = Color.White;
                        ((SwitchButton)bindable).LeftLabel.TextColor = (Color)Application.Current.Resources["TextColorLightBlack"];

                        ((SwitchButton)bindable).RightLabel.TextColor = Color.White;
                        ((SwitchButton)bindable).RightBoxView.BackgroundColor = (Color)Application.Current.Resources["TextColorNearBlack"];
                    }
                }
                ((SwitchButton)bindable).InvalidateLayout();
            });

        public string LeftText {
            get { return (string)GetValue(LeftTextProperty); }
            set { SetValue(LeftTextProperty, value ?? throw new NullReferenceException("LeftText value cannot be null or empty string.")); }
        }

        public static BindableProperty LeftTextProperty { get; } = BindableProperty.Create(
            "LeftText",
            typeof(string),
            typeof(SwitchButton),
            "Enthusiast",
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                ((SwitchButton)bindable).LeftLabel.Text = ((SwitchButton)bindable).LeftText;
                ((SwitchButton)bindable).InvalidateLayout();
            });

        public string RightText {
            get { return (string)GetValue(RightTextProperty); }
            set { SetValue(RightTextProperty, value ?? throw new NullReferenceException("RightText value cannot be null or empty string.")); }
        }

        public static BindableProperty RightTextProperty { get; } = BindableProperty.Create(
            "RightText",
            typeof(string),
            typeof(SwitchButton),
            "Professional",
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                ((SwitchButton)bindable).RightLabel.Text = ((SwitchButton)bindable).RightText;
                ((SwitchButton)bindable).InvalidateLayout();
            });

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            double[] NeededSizes = GetNeededSizes();
            Size totalSize = new Size(NeededSizes[0], NeededSizes[1]);
            //return base.OnMeasure(widthConstraint, heightConstraint);
            return new SizeRequest(totalSize);
        }

        private double[] GetNeededSizes()
        {
            double _neededHeight = 0;
            double _neededWidth = 0;
            SizeRequest LeftLabelRequest = LeftLabel.Measure(double.PositiveInfinity, double.PositiveInfinity, MeasureFlags.IncludeMargins);
            SizeRequest RightLabelRequest = RightLabel.Measure(double.PositiveInfinity, double.PositiveInfinity, MeasureFlags.IncludeMargins);
            _neededWidth += LeftLabelRequest.Request.Width + 24;
            _neededHeight = Math.Max(_neededHeight, LeftLabelRequest.Request.Height);
            _neededWidth += RightLabelRequest.Request.Width + 24;
            _neededHeight = Math.Max(_neededHeight, RightLabelRequest.Request.Height) + 8;
            return new double[] { _neededWidth, _neededHeight };
        }
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
        }

        public void ToggleSwitch()
        {
            SwitchPosition = SwitchPosition == SwitchPositions.Left ? SwitchPositions.Right : SwitchPositions.Left;
        }

        public AccountTypes GetAccountType()
        {
            return SwitchPosition == SwitchPositions.Left ? AccountTypes.Professional : AccountTypes.Enthusiast;
        }
    }
}
