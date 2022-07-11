using AppointmentsPoc.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace AppointmentsPoc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Appointments()
        {
            ViewBag.Message = "Agendamento pelo usuário.";

            var file1 = Path.Combine(Server.MapPath("~/app_data"), "especialidades.xml");
            var file2 = Path.Combine(Server.MapPath("~/app_data"), "animal.xml");
            var model = new AppointmentsModel
            {
                Especialidades =
                    from unit in XDocument.Load(file1).Document.Descendants("item")
                    select new SelectListItem
                    {
                        Value = unit.Attribute("id").Value,
                        Text = unit.Attribute("nome").Value
                    }
            };

            model.Animais = GetAnimal("1");
            List<SelectListItem> tag = new List<SelectListItem>();
            tag.Add(new SelectListItem { Value = "", Text = "" });
            model.Local = tag;
            model.XML_SOURCE = Path.Combine(Server.MapPath("~/app_data"), "agenda.xml");
            model.XSLT_SOURCE = Path.Combine(Server.MapPath("~/app_data"), "lst_agenda.xslt");
            return View(model);
        }

        public JsonResult GetLocal(string id)
        {
            List<KeyValue> result = new List<KeyValue>();
            if (id != "")
            {
                var file = Path.Combine(Server.MapPath("~/app_data"), "especialidade_local.xml");

                var query = XDocument.Load(file).Document.Descendants("item").Where(x => x.Attribute("idesp").Value == id);
                foreach (var item in query)
                {
                    var idlocal = item.Attribute("idlocal").Value;
                    var file1 = Path.Combine(Server.MapPath("~/app_data"), "locais.xml");
                    var query1 = XDocument.Load(file1).Document.Descendants("item").Where(y => y.Attribute("id").Value == idlocal);

                    if (query1 != null)
                    {
                        foreach (var item2 in query1)
                        {
                            result.Add(new KeyValue(item2.Attribute("id").Value, item2.Attribute("nome").Value));
                        }
                    }
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProfissional(string id)
        {
            List<KeyValue> result = new List<KeyValue>();
            if (id != "")
            {
                var file = Path.Combine(Server.MapPath("~/app_data"), "profissional_local.xml");

                var query = XDocument.Load(file).Document.Descendants("item").Where(x => x.Attribute("idlocal").Value == id);
                foreach (var item in query)
                {
                    var idprof = item.Attribute("idprof").Value;
                    var file1 = Path.Combine(Server.MapPath("~/app_data"), "profissional.xml");
                    var query1 = XDocument.Load(file1).Document.Descendants("item").Where(y => y.Attribute("id").Value == idprof);

                    if (query1 != null)
                    {
                        foreach (var item2 in query1)
                        {
                            result.Add(new KeyValue(item2.Attribute("id").Value, item2.Attribute("nome").Value));
                        }
                    }
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> GetAnimal(string id)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            if (id != "")
            {
                var file = Path.Combine(Server.MapPath("~/app_data"), "animal.xml");

                var query = XDocument.Load(file).Document.Descendants("item").Where(x => x.Attribute("idpessoa").Value == id);
                foreach (var item in query)
                {
                    result.Add(new SelectListItem { Value = item.Attribute("idanimal").Value, Text = item.Attribute("nome").Value });
                }

            }
            return result;
        }
    }
}