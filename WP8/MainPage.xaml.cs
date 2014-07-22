using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WP8.Resources;
using WP8.Views;
using CommonComponents.Dialog;
using WP8.Dialog;

namespace WP8
{
    public partial class MainPage : PhoneApplicationPage
    {

        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<DialogButtonType> buttonList = new List<DialogButtonType>();

            DialogService messageBox = new DialogService(); 

            buttonList.Add(DialogButtonType.DIALOG_OK);
            buttonList.Add(DialogButtonType.DIALOG_CANCEL);
            buttonList.Add(DialogButtonType.DIALOG_DISCARD);
            

            messageBox.Show("This is sample text!", "header", buttonList);

        }
    }
}