using CommonComponents.Dialog;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WP8.ViewModel;
using WP8.Views;

namespace WP8.Dialog
{
    public class DialogService : IDialogService
    {
        
        MessageBoxUserControl msgBox;
        MessageBoxViewModel msgVM;

        public DialogService()
        {
             
        }

        public DialogButtonType Show(string message, string caption, IEnumerable<DialogButtonType> dialogButtonType)
        {


            msgBox = SimpleIoc.Default.GetInstance<MessageBoxUserControl>();

            msgVM = SimpleIoc.Default.GetInstance<MessageBoxViewModel>();


            msgBox.DataContext = msgVM;

            msgVM.Title = caption;
            msgVM.Message = message;

            List<DialogButtonType> buttonList = dialogButtonType.ToList<DialogButtonType>();


            int i = buttonList.Count;

            if (i < 2)
            {
                FirstButton(buttonList.ElementAt(0));
            }
            else if (i == 2)
            {
                msgVM.SecondIsVisible = "Visible";
                FirstButton(buttonList.ElementAt(0));
                SecondButton(buttonList.ElementAt(1));
            }
            else
            {
                msgVM.SecondIsVisible = "Visible";
                msgVM.ThirdIsVisible = "Visible";
                FirstButton(buttonList.ElementAt(0));
                SecondButton(buttonList.ElementAt(1));
                ThirdButton(buttonList.ElementAt(2));
            }

            
            msgVM.Insert(msgBox);

            return msgVM.DialogType;
        }

        private void FirstButton(DialogButtonType button)
        {
            switch (button)
            {
                case DialogButtonType.DIALOG_OK:
                    msgVM.FirstButtonText = "Ok";
                    break;
                case DialogButtonType.DIALOG_CANCEL:
                    msgVM.FirstButtonText = "Cancel";
                    break;
                case DialogButtonType.DIALOG_YES:
                    msgVM.FirstButtonText = "Yes";
                    break;
                case DialogButtonType.DIALOG_NO:
                    msgVM.FirstButtonText = "No";
                    break;
                case DialogButtonType.DIALOG_SAVE:
                    msgVM.FirstButtonText = "Save";
                    break;
                case DialogButtonType.DIALOG_DISCARD:
                    msgVM.FirstButtonText = "Discard";
                    break;
                default:
                    break;
            }
        }

        private void SecondButton(DialogButtonType button)
        {
            switch (button)
            {
                case DialogButtonType.DIALOG_OK:
                    msgVM.SecondButtonText = "Ok";
                    break;
                case DialogButtonType.DIALOG_CANCEL:
                    msgVM.SecondButtonText = "Cancel";
                    break;
                case DialogButtonType.DIALOG_YES:
                    msgVM.SecondButtonText = "Yes";
                    break;
                case DialogButtonType.DIALOG_NO:
                    msgVM.SecondButtonText = "No";
                    break;
                case DialogButtonType.DIALOG_SAVE:
                    msgVM.SecondButtonText = "Save";
                    break;
                case DialogButtonType.DIALOG_DISCARD:
                    msgVM.SecondButtonText = "Discard";
                    break;
                default:
                    break;
            }
        }

        private void ThirdButton(DialogButtonType button)
        {
            switch (button)
            {
                case DialogButtonType.DIALOG_OK:
                    msgVM.ThirdButtonText = "Ok";
                    break;
                case DialogButtonType.DIALOG_CANCEL:
                    msgVM.ThirdButtonText = "Cancel";
                    break;
                case DialogButtonType.DIALOG_YES:
                    msgVM.ThirdButtonText = "Yes";
                    break;
                case DialogButtonType.DIALOG_NO:
                    msgVM.ThirdButtonText = "No";
                    break;
                case DialogButtonType.DIALOG_SAVE:
                    msgVM.ThirdButtonText = "Save";
                    break;
                case DialogButtonType.DIALOG_DISCARD:
                    msgVM.ThirdButtonText = "Discard";
                    break;
                default:
                    break;
            }
        }

    }
}
