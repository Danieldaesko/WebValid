using System;
using System.Collections.Generic;
using System.Xml;

namespace WebValid
{
    public partial class app : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("login.aspx");

            if (!IsPostBack)
                CarregarNoticias();
        }

        void CarregarNoticias()
        {
            string rssUrl = "https://feeds.feedburner.com/TechCrunch";
            var lista = new List<Noticia>();
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(rssUrl);
                XmlNodeList items = xml.SelectNodes("//item");
                foreach (XmlNode item in items)
                {
                    string titulo = item["title"]?.InnerText ?? "";
                    string link = item["link"]?.InnerText ?? "#";
                    string data = item["pubDate"]?.InnerText ?? "";
                    string imagem = "https://placehold.co/80x60?text=Tech";
                    XmlNode enc = item["enclosure"];
                    if (enc != null)
                        imagem = enc.Attributes["url"]?.Value ?? imagem;
                    lista.Add(new Noticia { Titulo = titulo, Link = link, Data = data, Imagem = imagem });
                }
            }
            catch { }
            gvNoticias.DataSource = lista;
            gvNoticias.DataBind();
        }

        public class Noticia
        {
            public string Titulo { get; set; }
            public string Link { get; set; }
            public string Data { get; set; }
            public string Imagem { get; set; }
        }
    }
}