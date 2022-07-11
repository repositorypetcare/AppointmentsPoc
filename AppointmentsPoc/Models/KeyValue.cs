namespace AppointmentsPoc.Models
{
    public class KeyValue
    {
        public string Key { get; set; }
        public string Text { get; set; }

        public KeyValue(string key, string text)
        {
            Key = key;
            Text = text;
        }
    }
}