using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace Showmie.Views
{
    public class HScrollview : ScrollView
    {
        public string SortPattern {
            get { return (string)GetValue(SortPatternProperty); }
            set { SetValue(SortPatternProperty, value ?? throw new NullReferenceException("SortPattern value cannot be null or empty string.")); }
        }

        public static BindableProperty SortPatternProperty { get; } = BindableProperty.Create(
            "SortPattern",
            typeof(string),
            typeof(HScrollview),
            "Most Recent",
            defaultBindingMode: BindingMode.Default,
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                var DesignsScrollViewer = bindable as HScrollview;
                if (!(newvalue is string) && !string.IsNullOrWhiteSpace(newvalue as string))
                {
                    if (oldvalue != newvalue)
                    {
                        DesignsScrollViewer.Render();
                    }
                }

            });

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource",
                typeof(IEnumerable),
                typeof(HScrollview),
                default(IEnumerable),
                defaultBindingMode: BindingMode.Default,
                validateValue: null,
                propertyChanged: new BindableProperty.BindingPropertyChangedDelegate(HandleBindingPropertyChangedDelegate));

        private static void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            var isOldObservable = oldValue?.GetType().GetTypeInfo().ImplementedInterfaces.Any(i => i == typeof(INotifyCollectionChanged));
            var isNewObservable = newValue?.GetType().GetTypeInfo().ImplementedInterfaces.Any(i => i == typeof(INotifyCollectionChanged));

            var tl = (HScrollview)bindable;
            if (isOldObservable.GetValueOrDefault(false))
            {
                ((INotifyCollectionChanged)oldValue).CollectionChanged -= tl.HandleCollectionChanged;
            }

            if (isNewObservable.GetValueOrDefault(false))
            {
                ((INotifyCollectionChanged)newValue).CollectionChanged += tl.HandleCollectionChanged;
            }

            if (oldValue != newValue)
            {
                tl.Render();
            }
        }

        public IEnumerable ItemsSource {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create("ItemTemplate",
                typeof(DataTemplate),
                typeof(HScrollview),
                default(DataTemplate));

        public DataTemplate ItemTemplate {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public event EventHandler<ItemTappedEventArgs> ItemSelected;

        public static readonly BindableProperty SelectedCommandProperty =
            BindableProperty.Create("SelectedCommand",
                typeof(ICommand),
                typeof(HScrollview),
                null);

        public ICommand SelectedCommand {
            get { return (ICommand)GetValue(SelectedCommandProperty); }
            set { SetValue(SelectedCommandProperty, value); }
        }

        public static readonly BindableProperty SelectedCommandParameterProperty =
            BindableProperty.Create("SelectedCommandParameter", typeof(object), typeof(HScrollview), null);

        public object SelectedCommandParameter {
            get { return GetValue(SelectedCommandParameterProperty); }
            set { SetValue(SelectedCommandParameterProperty, value); }
        }


        private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Render();
        }

        public void Render()
        {
            if (ItemTemplate == null || ItemsSource == null)
            {
                Content = null;
                return;
            }
            var designsStack = new StackLayout
            {
                Orientation = Orientation == ScrollOrientation.Vertical ? StackOrientation.Vertical : StackOrientation.Horizontal,
                Spacing = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) / 1.2
            };

            foreach (var item in ItemsSource)
            {
                var command = SelectedCommand ?? new Command((obj) =>
                {
                    var args = new ItemTappedEventArgs(ItemsSource, item);
                    ItemSelected?.Invoke(this, args);
                });
                var commandParameter = SelectedCommandParameter ?? item;

                var viewCell = ItemTemplate.CreateContent() as ViewCell;
                viewCell.View.BindingContext = item;
                viewCell.View.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = command,
                    CommandParameter = commandParameter,
                    NumberOfTapsRequired = 1
                });

                designsStack.Children.Add(viewCell.View);
            }

            var layout = new StackLayout() { Orientation = StackOrientation.Vertical };
            layout.Children.Add(designsStack);
            Content = layout;
        }

        private void OnScrolled(object sender, ScrolledEventArgs e)
        {
            HScrollview scrollView = sender as HScrollview;
            double scrollingSpace = scrollView.ContentSize.Width - scrollView.Width;

            if (scrollingSpace <= e.ScrollX)
            {
                Console.WriteLine("Buyakasha");
            }
        }
    }
}
