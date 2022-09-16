using PropertyChanged;

namespace _02_file_copier
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public double Progress { get; set; }
        public bool IsWaiting => Progress == 0;

        // TODO: move methods here
    }
}
