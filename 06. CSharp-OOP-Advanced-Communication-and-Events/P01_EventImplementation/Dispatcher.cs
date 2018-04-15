namespace P01_EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs e);

    public class Dispatcher
    {
        private string name;

        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get{return this.name;}
            set
            {
                this.name = value;
                this.OnNamechange(new NameChangeEventArgs(value));
            }
        }

        private void OnNamechange(NameChangeEventArgs nameChangeEventArgs)
        {
            if (this.NameChange != null)
            {
                this.NameChange(this, nameChangeEventArgs);
            }
        }
    }
}
