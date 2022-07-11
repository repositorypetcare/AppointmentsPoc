using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Xsl;

namespace AppointmentsPoc
{
    public class Utils
    {
        public static string Transform(string XmlString, string XsltFile)
        {

            StringBuilder sb = new StringBuilder();


            if (XmlString != "")

            {

                try

                {

                    XslCompiledTransform xslDoc = new XslCompiledTransform();

                    XsltSettings settings = new XsltSettings(false, true);

                    XsltArgumentList Args = new XsltArgumentList();

                    settings.EnableDocumentFunction = true;

                    xslDoc.Load(XsltFile, settings, new XmlUrlResolver());

                    StringWriter stringWriter = new StringWriter(sb);

                    XsltUtil obj = new XsltUtil();

                    Args.AddExtensionObject("urn:util", obj);

                    xslDoc.Transform(XmlReader.Create(new StringReader(XmlString)), Args, stringWriter);

                    stringWriter.Close();

                    return sb.ToString();

                }

                catch (Exception Error)

                {

                }
            }
            return "";
        }
    }
    public class XsltUtil
    {
        public string FormatDate(string d)
        {
            DateTime y = Convert.ToDateTime(d);
            return y.ToString("HH:mm");
        }
    }
    public static class XmlHelper
    {
        public static HtmlString RenderXml(this HtmlHelper helper, string xml, string xsltPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            string x = Utils.Transform(doc.OuterXml, xsltPath);
            HtmlString htmlString = new HtmlString(x.ToString());  //HTML string from StringWriter is generated
            doc = null;
            return htmlString;
            //XsltArgumentList args = new XsltArgumentList();

            //XslCompiledTransform tranformObj = new XslCompiledTransform(); // XslCompiledTransform object is created to load and compile XSLT file

            //tranformObj.Load(xsltPath);



            //XmlReaderSettings xmlSettings = new XmlReaderSettings(); // XMLReaderSetting object is created for assigning DtdProcessing, Validation type 

            //xmlSettings.DtdProcessing = DtdProcessing.Parse;

            //xmlSettings.ValidationType = ValidationType.DTD;



            //// Create XMLReader object to Transform xml value with XSLT setting  

            //using (XmlReader reader = XmlReader.Create(new StringReader(xml), xmlSettings))

            //{

            //    StringWriter writer = new StringWriter();

            //    tranformObj.Transform(reader, args, writer);



            //    HtmlString htmlString = new HtmlString(writer.ToString());  //HTML string from StringWriter is generated

            //    return htmlString;

        }


    }
}