﻿using Android.Widget;
using System;
using Xamarin.Forms;

namespace Showmie.Views.CustomViews
{
    internal class CustomCheckbox : View
    {
        private static BindableProperty IsCheckedProperty { get; } = BindableProperty.Create(
           "IsChecked",
           typeof(bool),
           typeof(CustomCheckbox),
           false,
           propertyChanged: OnCheckedChanged);

        public bool IsChecked {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static void OnCheckedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Console.WriteLine("Is Checked: " + newValue.ToString());
        }

        public string FontFamily {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value ?? throw new NullReferenceException("FontFamily value cannot be null or empty string.")); }
        }

        public static BindableProperty FontFamilyProperty { get; } = BindableProperty.Create(
            "FontFamily",
            typeof(string),
            typeof(CustomCheckbox),
            "Quicksand-Regular.ttf",
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                //((SwitchButton)bindable).RightLabel.Text = ((SwitchButton)bindable).RightText;
                //((SwitchButton)bindable).InvalidateLayout();
            });

        public int TextSize {
            get { return (int)GetValue(TextSizeProperty); }
            set { SetValue(TextSizeProperty, value); }
        }

        public static BindableProperty TextSizeProperty { get; } = BindableProperty.Create(
            "TextSize",
            typeof(int),
            typeof(CustomCheckbox),
            14,
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                //((SwitchButton)bindable).RightLabel.Text = ((SwitchButton)bindable).RightText;
                //((SwitchButton)bindable).InvalidateLayout();
            });

        internal void CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            IsChecked = e.IsChecked;
        }

        public string Label {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value ?? throw new NullReferenceException("Label value cannot be null or empty string.")); }
        }

        public static BindableProperty LabelProperty { get; } = BindableProperty.Create(
            "Label",
            typeof(string),
            typeof(CustomCheckbox),
            "CheckBox",
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                //((SwitchButton)bindable).RightLabel.Text = ((SwitchButton)bindable).RightText;
                //((SwitchButton)bindable).InvalidateLayout();
            });

        public Color CheckedBackgroundColor {
            get { return (Color)GetValue(CheckedBackgroundColorProperty); }
            set { SetValue(CheckedBackgroundColorProperty, value); }
        }

        public static BindableProperty CheckedBackgroundColorProperty { get; } = BindableProperty.Create(
            "CheckedBackgroundColor",
            typeof(Color),
            typeof(CustomCheckbox),
            Color.FromHex("#000000"),
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                //((SwitchButton)bindable).RightLabel.Text = ((SwitchButton)bindable).RightText;
                //((SwitchButton)bindable).InvalidateLayout();
            });

        public Color LabelColor {
            get { return (Color)GetValue(LabelColorProperty); }
            set { SetValue(LabelColorProperty, value); }
        }

        public static BindableProperty LabelColorProperty { get; } = BindableProperty.Create(
            "LabelColor",
            typeof(Color),
            typeof(CustomCheckbox),
            Color.FromHex("#000000"),
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                //((SwitchButton)bindable).RightLabel.Text = ((SwitchButton)bindable).RightText;
                //((SwitchButton)bindable).InvalidateLayout();
            });


        public Color UnCheckedBackgroundColor {
            get { return (Color)GetValue(UnCheckedBackgroundColorProperty); }
            set { SetValue(UnCheckedBackgroundColorProperty, value); }
        }

        public static BindableProperty UnCheckedBackgroundColorProperty { get; } = BindableProperty.Create(
            "UnCheckedBackgroundColor",
            typeof(Color),
            typeof(CustomCheckbox),
           Color.FromHex("#EBEBEB"),
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                //((SwitchButton)bindable).RightLabel.Text = ((SwitchButton)bindable).RightText;
                //((SwitchButton)bindable).InvalidateLayout();
            });


        // public static readonly BindableProperty FontSizeFactorProperty =
        //BindableProperty.Create(
        //"FontSizeFactor", typeof(double), typeof(CustomLabel),
        //defaultValue: 1.0, propertyChanged: OnFontSizeFactorChanged);
    }
}
