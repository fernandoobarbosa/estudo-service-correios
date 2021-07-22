using IronPython.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using static WebApplication2.PreLista;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var correios = new Correios.AtendeClienteClient();

            var binding = correios.Endpoint.Binding;
            if (binding is BasicHttpBinding)
            {
                ((BasicHttpBinding)binding).MaxReceivedMessageSize = 100000000;
            }
            else if (binding is WSHttpBinding)
            {
                ((WSHttpBinding)binding).MaxReceivedMessageSize = 1000000;
            }
            else
            {
                // outros tipos
                var newBinding = new CustomBinding(binding);
                for (var i = 0; i < newBinding.Elements.Count; i++)
                {
                    if (newBinding.Elements[i] is TransportBindingElement)
                    {
                        ((TransportBindingElement)newBinding.Elements[i]).MaxReceivedMessageSize = 1000000;
                    }
                }

                correios.Endpoint.Binding = newBinding;
            }

            try
            {

                //var cliente = correios.buscaCliente("9992157880", "0067599079", "sigep", "n5f9t8");
                //var servicos = correios.buscaServicos("9992157880", "0067599079", "sigep", "n5f9t8");
               
                
                string usuario = "sigep";
                string senha = "n5f9t8";

                //var estaDisponivel = correios.verificaDisponibilidadeServico(17000190, servicos[1].codigo, "09580620", "09510101", usuario, senha);
               
               
                //var idServico = cliente;

                // var etiquetas = correios.solicitaEtiquetas("C", "34028316000103", servicos[0].id, 2, "sigep", "n5f9t8");
                //Antes de enviar os objetos da lista parapostagem a PLP deverá ser fechada
                // var xmlPlp = correios.solicitaXmlPlp(1234, "sigep", "n5f9t8");
                var cliente = correios.buscaCliente("9992157880", "0067599079", usuario, senha);

                var servicos = cliente.contratos[0].cartoesPostagem[0].servicos;

                //an instance of the class Learning is created
                Correioslog c = new Correioslog();
                c.Remetente = new Remetente();
                c.Plp = new Plp();
                c.ObjetoPostal = new List<ObjetoPostal>();
                c.TipoArquivo = "Postagem";

                var cep = correios.consultaCEP("09510000");
                
                c.Plp.CartaoPostagem = 0067599079;
                c.Remetente.NumeroContrato = 9992157880;
                c.Remetente.NumeroDiretoria = 72;
                c.Remetente.CodigoAdministrativo = 17000190;
                c.Remetente.NomeRemetente = "Correios Teste";
                c.Remetente.LogradouroRemetente = cep.end;
                c.Remetente.NumeroRemetente = 123;
                c.Remetente.ComplementoRemetente = cep.complemento2;
                c.Remetente.BairroRemetente = cep.bairro;
                c.Remetente.CepRemetente = int.Parse(cep.cep);
                c.Remetente.CidadeRemetente = cep.cidade;
                c.Remetente.UfRemetente = cep.uf;

                //var servicos = correios.buscaServicos("9992157880", "0067599079", "sigep", "n5f9t8");
                
                var etiquetas = correios.solicitaEtiquetas("C", "34028316000103", servicos[0].id, 2, usuario, senha);

             
                string[] numeroObjetos = etiquetas.Split(' ',',');

                string[] etiquetasArray = etiquetas.Split(',');

                

                List<string> vs = new List<string>();
                
                foreach(string etiqueta in etiquetasArray)
                {
                    string trimmed = String.Concat(etiqueta.Where(et => !Char.IsWhiteSpace(et)));
                    vs.Add(trimmed);
                }

                var digito = correios.geraDigitoVerificadorEtiquetas(etiquetasArray, usuario,senha);

                //Importante: Deverá constar no códigodoobjeto:
                //Sigla do Tipo Postal(ex: DW) +númerodo objeto + digito verificador + BR.Exemplo: DW123456785BR

                string etiquetaTesteCancelamento = "";


                for (int i = 0; i < etiquetasArray.Length; i++)
                {
                    ObjetoPostal objetoPostal = new ObjetoPostal();

                    string etiquetaMontada = numeroObjetos[i * 2] + digito[i] + "BR";
                    etiquetaTesteCancelamento = etiquetaMontada;
                    //objetoPostal.NumeroEtiqueta = numeroObjetos[i *2];
                    objetoPostal.NumeroEtiqueta = etiquetaMontada;
                    objetoPostal.CodigoServicoPostagem = ((int)servicos[0].id);
                    objetoPostal.Cubagem = 0.00;
                    objetoPostal.Peso = 10;
                    //objetoPostal.Destinatario = new Destinatario();
                    Destinatario destinatario = new Destinatario();
                    
                    destinatario.NumeroEndDestinatario = 123;
                    destinatario.LogradouroDestinatario = "Rua das ruas";
                    destinatario.NomeDestinatario = "Venturi";
                    objetoPostal.Destinatario = destinatario;

                    Nacional nacional = new Nacional();

                    var cepDestinatario = correios.consultaCEP("09510101");
                    nacional.BairroDestinatario = cepDestinatario.bairro;
                    nacional.CidadeDestinatario = cepDestinatario.cidade;
                    nacional.UfDestinatario = cepDestinatario.uf;
                    nacional.CepDestinatario = int.Parse(cepDestinatario.cep);
                    objetoPostal.Nacional = nacional;

                 
                    c.ObjetoPostal.Add(objetoPostal);
                }

                
             
                //an instance of the XmlSerializer class is created
                XmlSerializer inst = new XmlSerializer(typeof(Correioslog));
                //an instance of the TextWriter class is created to write the converted XML string to the file
                TextWriter writer = new StreamWriter(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString()) + @"\tb_cid.xml");
                inst.Serialize(writer, c);
                writer.Close();

                //XmlDocument doc = new XmlDocument();
                //doc.Load(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString()) + @"\tb_cid.xml");

                XmlDocument doc = new XmlDocument();

                doc.Load(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString()) + @"\tb_cid.xml");
                StringWriter sw = new StringWriter();
                XmlTextWriter tx = new XmlTextWriter(sw);
                doc.WriteTo(tx);
               

                //var idPlp = correios.fechaPlp(sw.ToString(), 1234, "0067599079", etiquetas, usuario,senha);

                var PlpVariosServicos = correios.fechaPlpVariosServicos(sw.ToString(), cliente.id, "0067599079",vs.ToArray(), usuario, senha);
                

                //var obterPlp = correios.solicitaXmlPlp(idPlp, "sigep", "n5f9t8");
                
                //cancelando com a etiqueta com digito verificador

                var cancelamento = correios.cancelarObjeto(PlpVariosServicos,etiquetaTesteCancelamento, usuario,senha);

                var teste = correios.solicitaXmlPlp(PlpVariosServicos, usuario, senha);
                var x = correios.solicitaXmlPlp(PlpVariosServicos, usuario, senha);

                //var idPlp = correios.fechaPlp(sw.ToString(), 1234, "0067599079", etiquetas, usuario, senha);
            }
            catch (Exception ex)
            {

            }

        }
    }
}