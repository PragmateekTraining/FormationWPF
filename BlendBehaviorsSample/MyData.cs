using Common;

namespace BlendBehaviorsSample
{
    public class MyData : NotifyPropertyChangedBase
    {
        private string header;
        public string Header
        {
            get { return header; }
            set { UpdateAndNotify(ref header, value); }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set { UpdateAndNotify(ref content, value); }
        }
    }
}
