using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.HelperToast
{
    [Serializable]
    public class Toastr
    {
        public bool ShowNewestOnTop { get; set; }
        public bool ShowCloseButton { get; set; }
        public bool IsSticky { get; set; }
        public bool ProgressBar { get; set; }
        public List<ToastMessage> ToastMessages { get; set; }

        public ToastMessage AddToastMessage(string title, string message, ToastType toastType)
        {
            var toast = new ToastMessage()
            {
                Title = title,
                Message = message,
                ToastType = toastType,


            };
            ToastMessages.Add(toast);
            return toast;
        }

        public Toastr()
        {
            ToastMessages = new List<ToastMessage>();
            ShowNewestOnTop = true;
            ShowCloseButton = false;
            IsSticky = true;
            ProgressBar = true;
        }

    }
}
