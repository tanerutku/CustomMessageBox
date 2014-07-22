using CommonComponents.Dialog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WP8.Dialog;
using WP8.Views;

namespace WP8.ViewModel
{
    public class MessageBoxViewModel: ViewModelBase
    {
        private string _title = "";
        private string _message = "";
        private string _firstButtonText = "";
        private string _secondButtonText = "";
        private string _thirdButtonText = "";
        private string _secondIsVisible = "Collapsed";
        private string _thirdIsVisible = "Collapsed";
        private DialogButtonType _dialogType;
        IDialogService _dialogService;
        private DialogButtonType _result;
        private string _dialogTypeString;

        private PhoneApplicationPage _page;
        private Color _originalTrayColor;

        Rectangle rectangle = new Rectangle();


        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                Set(ref _title, value);
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                Set(ref _message, value);
            }
        }

        public string FirstButtonText
        {
            get
            {
                return _firstButtonText;
            }
            set
            {
                Set(ref _firstButtonText, value);
            }
        }

        public string SecondButtonText
        {
            get
            {
                return _secondButtonText;
            }
            set
            {
                Set(ref _secondButtonText, value);
            }
        }

        public string ThirdButtonText
        {
            get
            {
                return _thirdButtonText;
            }
            set
            {
                Set(ref _thirdButtonText, value);
            }
        }

        public string SecondIsVisible
        {
            get
            {
                return _secondIsVisible;
            }
            set
            {
                Set(ref _secondIsVisible, value);
            }
        }


        public string ThirdIsVisible
        {
            get
            {
                return _thirdIsVisible;
            }
            set
            {
                Set(ref _thirdIsVisible, value);
            }
        }

        public DialogButtonType DialogType
        {
            get
            {
                return _dialogType;
            }
            set
            {
                Set(ref _dialogType, value);
            }
        }

        public string DialogTypeString
        {
            get
            {
                return _dialogTypeString;
            }
            set
            {
                Set(ref _dialogTypeString, value);
            }
        }



        public RelayCommand<string> SetDialogType { get; private set; }

        public MessageBoxViewModel(IDialogService dialogService)
        {

            _dialogService = dialogService;
            if (SetDialogType == null)
            {
                SetDialogType = new RelayCommand<string>(p =>
                {
                    
                    DispatcherHelper.Initialize();

                    DispatcherHelper.RunAsync(() =>
                        {
                            
                            MessageBoxUserControl msgBox = SimpleIoc.Default.GetInstance<MessageBoxUserControl>();
                            Remove(msgBox, Int16.Parse(p));
                            //Remove(DialogButtonType.DIALOG_CANCEL);
                        });


                });
            }
        }

        public void Insert(MessageBoxUserControl msgBox)
        {
            var frame = Application.Current.RootVisual as Microsoft.Phone.Controls.PhoneApplicationFrame;
            _page = frame.Content as PhoneApplicationPage;

            

            _originalTrayColor = SystemTray.BackgroundColor;
            SystemTray.BackgroundColor = ((SolidColorBrush)Application.Current.Resources["PhoneChromeBrush"]).Color;


            var grid = System.Windows.Media.VisualTreeHelper.GetChild(_page,0) as Grid;
            if (grid.RowDefinitions.Count > 0)
            {
                Grid.SetRowSpan(rectangle, grid.RowDefinitions.Count);

                Grid.SetRowSpan(msgBox, grid.RowDefinitions.Count);
            }


            //Add Rectangle to unable to click grid's children
            rectangle.Width = Application.Current.Host.Content.ActualWidth;
            rectangle.Height = Application.Current.Host.Content.ActualHeight;
            SolidColorBrush color = new SolidColorBrush();
            color.Color = Colors.Black;
            rectangle.Fill = color;
            rectangle.Opacity = 0.5;

            grid.Children.Add(rectangle);
            //grid.Children.Clear();
            grid.Children.Add(msgBox);

            SwivelTransition transitionIn = new SwivelTransition();
            transitionIn.Mode = SwivelTransitionMode.BackwardIn;

            ITransition transition = transitionIn.GetTransition(msgBox);
            EventHandler transitionCompletedHandler = null;
            transitionCompletedHandler = (s, e) =>
            {
                transition.Completed -= transitionCompletedHandler;
                transition.Stop();
            };
            transition.Completed += transitionCompletedHandler;
            transition.Begin();
        }

        public void Remove(MessageBoxUserControl msgBox, int buttonResult)
        {

            var frame = (PhoneApplicationFrame)Application.Current.RootVisual;
            var page = frame.Content as PhoneApplicationPage;
            var grid = VisualTreeHelper.GetChild(page, 0) as Grid;


            switch (buttonResult)
            {
                case 0:
                    if (FirstButtonText == "Ok")
                        _result = DialogButtonType.DIALOG_OK;
                    else if (FirstButtonText == "Cancel")
                        _result = DialogButtonType.DIALOG_CANCEL;
                    else if (FirstButtonText == "Discard")
                        _result = DialogButtonType.DIALOG_DISCARD;
                    else if (FirstButtonText == "Yes")
                        _result = DialogButtonType.DIALOG_YES;
                    else if (FirstButtonText == "No")
                        _result = DialogButtonType.DIALOG_NO;
                    else if (FirstButtonText == "Save")
                        _result = DialogButtonType.DIALOG_SAVE;
                    break;

                case 1:
                    if (SecondButtonText == "Ok")
                        _result = DialogButtonType.DIALOG_OK;
                    else if (SecondButtonText == "Cancel")
                        _result = DialogButtonType.DIALOG_CANCEL;
                    else if (SecondButtonText == "Discard")
                        _result = DialogButtonType.DIALOG_DISCARD;
                    else if (SecondButtonText == "Yes")
                        _result = DialogButtonType.DIALOG_YES;
                    else if (SecondButtonText == "No")
                        _result = DialogButtonType.DIALOG_NO;
                    else if (SecondButtonText == "Save")
                        _result = DialogButtonType.DIALOG_SAVE;
                    break;

                case 2:
                    if (ThirdButtonText == "Ok")
                        _result = DialogButtonType.DIALOG_OK;
                    else if (ThirdButtonText == "Cancel")
                        _result = DialogButtonType.DIALOG_CANCEL;
                    else if (ThirdButtonText == "Discard")
                        _result = DialogButtonType.DIALOG_DISCARD;
                    else if (ThirdButtonText == "Yes")
                        _result = DialogButtonType.DIALOG_YES;
                    else if (ThirdButtonText == "No")
                        _result = DialogButtonType.DIALOG_NO;
                    else if (ThirdButtonText == "Save")
                        _result = DialogButtonType.DIALOG_SAVE;
                    break;
                    
            }
            
            // Create a transition like the regular MessageBox
            SwivelTransition transitionOut = new SwivelTransition();
            transitionOut.Mode = SwivelTransitionMode.BackwardOut;

            ITransition transition = transitionOut.GetTransition(msgBox);
            EventHandler transitionCompletedHandler = null;
            transitionCompletedHandler = (s, e) =>
            {
                transition.Completed -= transitionCompletedHandler;
                SystemTray.BackgroundColor = _originalTrayColor;
                transition.Stop();
                grid.Children.Remove(msgBox);
                grid.Children.Remove(rectangle);
                if (page.ApplicationBar != null)
                {
                    page.ApplicationBar.IsVisible = true;
                }
                
            };
            transition.Completed += transitionCompletedHandler;
            transition.Begin();
            DialogType = _result;
            DialogTypeString = _result.ToString();
        }
        
    }
}
