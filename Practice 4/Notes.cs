using System.Xml.Linq;

namespace Practice_4
{
    internal class Notes
    {
        public string name, description;
        public DateTime data;

        
        /*Notes(string nameX, string descriptionX, DateTime dataX)
        {
            name = nameX;
            description = descriptionX;
            data = dataX;
        }*/

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
