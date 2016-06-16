﻿#pragma checksum "C:\Users\mails\Documents\GitHub\Gravitas\WindowsApp2\Views\Marvel.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "318C91CBA990AF4E7A4083C512FBD66D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsApp2.Views
{
    partial class Marvel : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Image_Source(global::Windows.UI.Xaml.Controls.Image obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Media_ImageBrush_ImageSource(global::Windows.UI.Xaml.Media.ImageBrush obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.ImageSource = value;
            }
        };

        private class Marvel_obj14_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMarvel_Bindings
        {
            private global::WindowsApp2.Models.ComicBook dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj14;

            public Marvel_obj14_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 14:
                        this.obj14 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.Image)target);
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 global::WindowsApp2.Models.ComicBook data = args.NewValue as global::WindowsApp2.Models.ComicBook;
                 if (args.NewValue != null && data == null)
                 {
                    throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::WindowsApp2.Models.ComicBook was expected.");
                 }
                 this.SetDataRoot(data);
                 this.Update();
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                switch(args.Phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(args.Item as global::WindowsApp2.Models.ComicBook);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.Image)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::WindowsApp2.Models.ComicBook) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
            }

            // IMarvel_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // Marvel_obj14_Bindings

            public void SetDataRoot(global::WindowsApp2.Models.ComicBook newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::WindowsApp2.Models.ComicBook obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_thumbnail(obj.thumbnail, phase);
                    }
                }
            }
            private void Update_thumbnail(global::WindowsApp2.Models.Thumbnail obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_thumbnail_small(obj.small, phase);
                    }
                }
            }
            private void Update_thumbnail_small(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj14.Target as global::Windows.UI.Xaml.Controls.Image, (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), obj), null);
                }
            }
        }

        private class Marvel_obj18_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMarvel_Bindings
        {
            private global::WindowsApp2.Models.Character dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj19;
            private global::Windows.UI.Xaml.Media.ImageBrush obj20;

            public Marvel_obj18_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 19:
                        this.obj19 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 20:
                        this.obj20 = (global::Windows.UI.Xaml.Media.ImageBrush)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 global::WindowsApp2.Models.Character data = args.NewValue as global::WindowsApp2.Models.Character;
                 if (args.NewValue != null && data == null)
                 {
                    throw new global::System.ArgumentException("Incorrect type passed into template. Based on the x:DataType global::WindowsApp2.Models.Character was expected.");
                 }
                 this.SetDataRoot(data);
                 this.Update();
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                switch(args.Phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(args.Item as global::WindowsApp2.Models.Character);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            ((global::Windows.UI.Xaml.Controls.StackPanel)args.ItemContainer.ContentTemplateRoot).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::WindowsApp2.Models.Character) args.Item, 1 << (int)args.Phase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
            }

            // IMarvel_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // Marvel_obj18_Bindings

            public void SetDataRoot(global::WindowsApp2.Models.Character newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::WindowsApp2.Models.Character obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_name(obj.name, phase);
                        this.Update_thumbnail(obj.thumbnail, phase);
                    }
                }
            }
            private void Update_name(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj19, obj, null);
                }
            }
            private void Update_thumbnail(global::WindowsApp2.Models.Thumbnail obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_thumbnail_small(obj.small, phase);
                    }
                }
            }
            private void Update_thumbnail_small(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Media_ImageBrush_ImageSource(this.obj20, (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), obj), null);
                }
            }
        }

        private class Marvel_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMarvel_Bindings
        {
            private global::WindowsApp2.Views.Marvel dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj7;
            private global::Windows.UI.Xaml.Controls.GridView obj10;

            public Marvel_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 7:
                        this.obj7 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    case 10:
                        this.obj10 = (global::Windows.UI.Xaml.Controls.GridView)target;
                        break;
                    default:
                        break;
                }
            }

            // IMarvel_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // Marvel_obj1_Bindings

            public void SetDataRoot(global::WindowsApp2.Views.Marvel newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::WindowsApp2.Views.Marvel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_MarvelCharacters(obj.MarvelCharacters, phase);
                        this.Update_MarvelComics(obj.MarvelComics, phase);
                    }
                }
            }
            private void Update_MarvelCharacters(global::System.Collections.ObjectModel.ObservableCollection<global::WindowsApp2.Models.Character> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj7, obj, null);
                }
            }
            private void Update_MarvelComics(global::System.Collections.ObjectModel.ObservableCollection<global::WindowsApp2.Models.ComicBook> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj10, obj, null);
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 8 "..\..\..\Views\Marvel.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.VisualStateGroup = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 3:
                {
                    this.Wide = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4:
                {
                    this.Narrow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 5:
                {
                    this.ColumnOne = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 6:
                {
                    this.ColumnTwo = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 7:
                {
                    this.MasterListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 55 "..\..\..\Views\Marvel.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MasterListView).ItemClick += this.MasterListView_ItemClick;
                    #line default
                }
                break;
            case 8:
                {
                    this.MyProgressRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 9:
                {
                    this.DetailGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 10:
                {
                    this.ComicsGridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 128 "..\..\..\Views\Marvel.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.ComicsGridView).ItemClick += this.ComicsGridView_ItemClick;
                    #line default
                }
                break;
            case 11:
                {
                    this.ComicDetailImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 12:
                {
                    this.ComicDetailNameTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.ComicDetailDescriptionTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15:
                {
                    this.DetailImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 16:
                {
                    this.DetailNameTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17:
                {
                    this.DetailDescriptionTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    Marvel_obj1_Bindings bindings = new Marvel_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            case 14:
                {
                    global::Windows.UI.Xaml.Controls.Image element14 = (global::Windows.UI.Xaml.Controls.Image)target;
                    Marvel_obj14_Bindings bindings = new Marvel_obj14_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot((global::WindowsApp2.Models.ComicBook) element14.DataContext);
                    element14.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element14, bindings);
                }
                break;
            case 18:
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element18 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    Marvel_obj18_Bindings bindings = new Marvel_obj18_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot((global::WindowsApp2.Models.Character) element18.DataContext);
                    element18.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element18, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

