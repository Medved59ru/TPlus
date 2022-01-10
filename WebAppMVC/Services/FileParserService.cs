using System.Xml;
using WebAppMVC.Dto;

namespace WebAppMVC.Services
{
    public class FileParserService
    {
        
        public HashSet<InitialDto>  GetDataFrom(Stream stream)
        {
            string? name = null;
            string? date = null;
            string? weather = null;
            string? consumption = null;
            string? price = null;
            HashSet<InitialDto> dtoSet = new HashSet<InitialDto>();

            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(stream);

            XmlElement? xRoot = xDoc.DocumentElement;



            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {

                    foreach (XmlNode xchild in xnode.ChildNodes)
                    {
                        var attributes = xchild.Attributes;

                        foreach (XmlAttribute attr in attributes)
                        {
                            if (attr.Name == "Name")
                            {
                                name = attr.Value;
                            }
                        }
                        foreach (XmlNode child in xchild.ChildNodes)
                        {
                            var list = child.Attributes;

                            foreach (XmlAttribute xattr in list)
                            {
                                if (xattr.Name == "Date")
                                {
                                    date = xattr.Value;
                                }
                                else if (xattr.Name == "Weather")
                                {
                                    weather = xattr.Value;
                                }
                                else if (xattr.Name == "Consumption")
                                {
                                    consumption = xattr.Value;
                                }
                                else if (xattr.Name == "Price")
                                {
                                    price = xattr.Value;
                                }

                            }
                            InitialDto localDto = new InitialDto() { Name = name, Date = date, Consumption = consumption, Weather = weather, Price = price };
                            dtoSet.Add(localDto);
                            date = consumption = weather = price = null;
                        }
                    }

                }
            }
          
            return dtoSet;

        }


       
    }
}
