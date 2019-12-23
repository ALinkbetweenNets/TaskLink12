using System;
using System.Threading.Tasks;

namespace TaskLink12Client
{
    public partial class TLC
    {

        private async void startup()
        {
            if (Silent)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                //backgroundWorkerReceiver.RunWorkerAsync();
                Hide();
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            RefreshReceiverStatus();
        }
    }
}
