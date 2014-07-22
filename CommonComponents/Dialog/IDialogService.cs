using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents.Dialog
{
    public interface IDialogService
    {
        DialogButtonType Show(string title, string message, IEnumerable<DialogButtonType> dialogButtonType);
    }
}
