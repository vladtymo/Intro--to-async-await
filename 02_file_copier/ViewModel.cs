using IOExtensions;
using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _02_file_copier
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private ObservableCollection<CopyProcessInfo> processes;

        public ViewModel()
        {
            processes = new ObservableCollection<CopyProcessInfo>();
        }

        public IEnumerable<CopyProcessInfo> Processes => processes;
        public string Source { get; set; }
        public string Destination { get; set; }
        public double TotalProgress { get; set; }
        public bool IsWaiting => TotalProgress == 0;

        public void AddProcess(CopyProcessInfo info)
        {
            processes.Add(info);
        }

        // TODO: move methods here
    }

    [AddINotifyPropertyChangedInterface]
    public class CopyProcessInfo
    {
        public string FileName { get; set; }
        public double Percentage { get; set; }
        public int PercentageInt => (int)Percentage;
        public double Speed { get; set; }
    }
}
