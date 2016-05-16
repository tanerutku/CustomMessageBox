##Windows Phone Custom Message Box

Windows Phone API has a regular message box. But the maximum number can be two in this message box control. Challenges may showing maximum three buttons and returning our own dialog types. I designed a new user control to achieve this challenge. 

#####The view of custom message box user control;

![Screenshot](https://github.com/tanerutku/Windows-Phone-Custom-Message-Box/raw/master/custommsgbox.png)

Usage is simple as seen below;
```javascript
            List<DialogButtonType> buttonList = new List<DialogButtonType>();

            DialogService messageBox = new DialogService(); 

            buttonList.Add(DialogButtonType.DIALOG_OK);
            buttonList.Add(DialogButtonType.DIALOG_CANCEL);
            buttonList.Add(DialogButtonType.DIALOG_DISCARD);
            

            messageBox.Show("This is sample text!", "header", buttonList);

