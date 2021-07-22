using HtmlParserSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplication2
{
    public class PreLista
    {
	

		[XmlRoot(ElementName = "plp")]
		public class Plp
		{

			[XmlElement(ElementName = "id_plp")]
			public object IdPlp { get; set; }

			[XmlElement(ElementName = "valor_global")]
			public object ValorGlobal { get; set; }

			[XmlElement(ElementName = "mcu_unidade_postagem")]
			public object McuUnidadePostagem { get; set; }

			[XmlElement(ElementName = "nome_unidade_postagem")]
			public object NomeUnidadePostagem { get; set; }

			[XmlElement(ElementName = "cartao_postagem")]
			public int CartaoPostagem { get; set; }
		}

		[XmlRoot(ElementName = "remetente")]
		public class Remetente
		{

			[XmlElement(ElementName = "numero_contrato")]
			public double NumeroContrato { get; set; }

			[XmlElement(ElementName = "numero_diretoria")]
			public int NumeroDiretoria { get; set; }

			[XmlElement(ElementName = "codigo_administrativo")]
			public int CodigoAdministrativo { get; set; }

			[XmlElement(ElementName = "nome_remetente")]
			public string NomeRemetente { get; set; }

			[XmlElement(ElementName = "logradouro_remetente")]
			public string LogradouroRemetente { get; set; }

			[XmlElement(ElementName = "numero_remetente")]
			public int NumeroRemetente { get; set; }

			[XmlElement(ElementName = "complemento_remetente")]
			public string ComplementoRemetente { get; set; }

			[XmlElement(ElementName = "bairro_remetente")]
			public string BairroRemetente { get; set; }

			[XmlElement(ElementName = "cep_remetente")]
			public int CepRemetente { get; set; }

			[XmlElement(ElementName = "cidade_remetente")]
			public string CidadeRemetente { get; set; }

			[XmlElement(ElementName = "uf_remetente")]
			public string UfRemetente { get; set; }

			[XmlElement(ElementName = "telefone_remetente")]
			public double TelefoneRemetente { get; set; }

			[XmlElement(ElementName = "fax_remetente")]
			public double FaxRemetente { get; set; }

			[XmlElement(ElementName = "email_remetente")]
			public string EmailRemetente { get; set; }

			[XmlElement(ElementName = "celular_remetente")]
			public object CelularRemetente { get; set; }

			[XmlElement(ElementName = "cpf_cnpj_remetente")]
			public object CpfCnpjRemetente { get; set; }

			[XmlElement(ElementName = "ciencia_conteudo_proibido")]
			public string CienciaConteudoProibido { get; set; }
		}

		[XmlRoot(ElementName = "destinatario")]
		public class Destinatario
		{

			[XmlElement(ElementName = "nome_destinatario")]
			public string NomeDestinatario { get; set; }

			[XmlElement(ElementName = "telefone_destinatario")]
			public double TelefoneDestinatario { get; set; }

			[XmlElement(ElementName = "celular_destinatario")]
			public double CelularDestinatario { get; set; }

			[XmlElement(ElementName = "email_destinatario")]
			public string EmailDestinatario { get; set; }

			[XmlElement(ElementName = "logradouro_destinatario")]
			public string LogradouroDestinatario { get; set; }

			[XmlElement(ElementName = "complemento_destinatario")]
			public string ComplementoDestinatario { get; set; }

			[XmlElement(ElementName = "numero_end_destinatario")]
			public int NumeroEndDestinatario { get; set; }

			[XmlElement(ElementName = "cpf_cnpj_destinatario")]
			public object CpfCnpjDestinatario { get; set; }
		}

		[XmlRoot(ElementName = "nacional")]
		public class Nacional
		{

			[XmlElement(ElementName = "bairro_destinatario")]
			public string BairroDestinatario { get; set; }

			[XmlElement(ElementName = "cidade_destinatario")]
			public string CidadeDestinatario { get; set; }

			[XmlElement(ElementName = "uf_destinatario")]
			public string UfDestinatario { get; set; }

			[XmlElement(ElementName = "cep_destinatario")]
			public int CepDestinatario { get; set; }

			[XmlElement(ElementName = "codigo_usuario_postal")]
			public object CodigoUsuarioPostal { get; set; }

			[XmlElement(ElementName = "centro_custo_cliente")]
			public object CentroCustoCliente { get; set; }

			[XmlElement(ElementName = "numero_nota_fiscal")]
			public int NumeroNotaFiscal { get; set; }

			[XmlElement(ElementName = "serie_nota_fiscal")]
			public object SerieNotaFiscal { get; set; }

			[XmlElement(ElementName = "valor_nota_fiscal")]
			public object ValorNotaFiscal { get; set; }

			[XmlElement(ElementName = "natureza_nota_fiscal")]
			public object NaturezaNotaFiscal { get; set; }

			[XmlElement(ElementName = "descricao_objeto")]
			public object DescricaoObjeto { get; set; }

			[XmlElement(ElementName = "valor_a_cobrar")]
			public double ValorACobrar { get; set; }
		}

		[XmlRoot(ElementName = "servico_adicional")]
		public class ServicoAdicional
		{

			[XmlElement(ElementName = "codigo_servico_adicional")]
			public List<int> CodigoServicoAdicional { get; set; }

			[XmlElement(ElementName = "valor_declarado")]
			public double ValorDeclarado { get; set; }
		}

		[XmlRoot(ElementName = "dimensao_objeto")]
		public class DimensaoObjeto
		{

			[XmlElement(ElementName = "tipo_objeto")]
			public int TipoObjeto { get; set; }

			[XmlElement(ElementName = "dimensao_altura")]
			public double DimensaoAltura { get; set; }

			[XmlElement(ElementName = "dimensao_largura")]
			public double DimensaoLargura { get; set; }

			[XmlElement(ElementName = "dimensao_comprimento")]
			public double DimensaoComprimento { get; set; }

			[XmlElement(ElementName = "dimensao_diametro")]
			public double DimensaoDiametro { get; set; }
		}

		[XmlRoot(ElementName = "objeto_postal")]
		public class ObjetoPostal
		{

			[XmlElement(ElementName = "numero_etiqueta")]
			public string NumeroEtiqueta { get; set; }

			[XmlElement(ElementName = "codigo_objeto_cliente")]
			public object CodigoObjetoCliente { get; set; }

			[XmlElement(ElementName = "codigo_servico_postagem")]
			public int CodigoServicoPostagem { get; set; }

			[XmlElement(ElementName = "cubagem")]
			public double Cubagem { get; set; }

			[XmlElement(ElementName = "peso")]
			public int Peso { get; set; }

			[XmlElement(ElementName = "rt1")]
			public object Rt1 { get; set; }

			[XmlElement(ElementName = "rt2")]
			public object Rt2 { get; set; }

			[XmlElement(ElementName = "restricao_anac")]
			public object RestricaoAnac { get; set; }

			[XmlElement(ElementName = "destinatario")]
			public Destinatario Destinatario { get; set; }

			[XmlElement(ElementName = "nacional")]
			public Nacional Nacional { get; set; }

			[XmlElement(ElementName = "servico_adicional")]
			public ServicoAdicional ServicoAdicional { get; set; }

			[XmlElement(ElementName = "dimensao_objeto")]
			public DimensaoObjeto DimensaoObjeto { get; set; }

			[XmlElement(ElementName = "data_postagem_sara")]
			public object DataPostagemSara { get; set; }

			[XmlElement(ElementName = "status_processamento")]
			public int StatusProcessamento { get; set; }

			[XmlElement(ElementName = "numero_comprovante_postagem")]
			public object NumeroComprovantePostagem { get; set; }

			[XmlElement(ElementName = "valor_cobrado")]
			public object ValorCobrado { get; set; }
		}

		[XmlRoot(ElementName = "correioslog")]
		public class Correioslog
		{

			[XmlElement(ElementName = "tipo_arquivo")]
			public string TipoArquivo { get; set; }

			[XmlElement(ElementName = "versao_arquivo")]
			public DateTime VersaoArquivo { get; set; }

			[XmlElement(ElementName = "plp")]
			public Plp Plp { get; set; }

			[XmlElement(ElementName = "remetente")]
			public Remetente Remetente { get; set; }

			[XmlElement(ElementName = "forma_pagamento")]
			public object FormaPagamento { get; set; }

			[XmlElement(ElementName = "objeto_postal")]
			public List<ObjetoPostal> ObjetoPostal { get; set; }
		}


	}
}