using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FIGeneradorFacturaElectronica;
using FIGeneradorFacturaElectronica.ComplementoConcepto;
using FIGeneradorFacturaElectronica.Complementos;


namespace EjemploTimbrarCFDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Datos Certificado
        private String ArchivoKey = "aaa010101aaa__csd_01.key";
        private String ArchivoCertificado = "aaa010101aaa__csd_01.cer";
        private String ContraseñaCertificado = "12345678a";
        private String NoCertificado = "20001000000100005867";
        private String PosicionCertificado = "E:\\Certificados\\";
        private string RFC = "aaa010101aaa";

        //datos Timbre
        private String CodigoUsuarioProveedor = "N#@Mo!)#oh>)BYOdX=q_ZUCsLxqpv?";
        private String CodigoUsuario = "1763AAB0593430490B3B3EE5457A9A2580F9D7DE";
        private int IdSucursal = 151048;

        private void btnTimbrar_Click(object sender, EventArgs e)
        {
            //crear un nuevo comprobante CFDI para la version 3.2
            FIGeneradorFacturaElectronica.ComprobanteCFDI32 Comprobante=new ComprobanteCFDI32();
            Comprobante.serie = "MER";
            Comprobante.folio = "8223"; //dato no obligatorio
            Comprobante.fecha = System.DateTime.Now;
            Comprobante.formaDePago = "Pago en una sola exhibición";
            Comprobante.subTotal = new FIGeneradorFacturaElectronica.Importe(1100);
            Comprobante.total = new FIGeneradorFacturaElectronica.Importe(1276);
            Comprobante.tipoDeComprobante = "ingreso";
            Comprobante.Moneda = "MXN";
            //Comprobante.TipoCambio = "1"; //utilizar en caso de moneda extranjera
            Comprobante.noCertificado = NoCertificado;

            // Campos nuevos en comprobante
            Comprobante.LugarExpedicion = "VERACRUZ";
            Comprobante.NumCtaPago = "NO IDENTIFICADO";
            Comprobante.metodoDePago = "NO IDENTIFICADO";

            //Campo nuevo en Emisor
            Comprobante.Emisor.RegimenFiscal.Add("REGIMEN GENERAL DE LEY PERSONAS MORALES");

            //Llenado de datos del emisor
            Comprobante.Emisor.rfc = RFC;
            Comprobante.Emisor.nombre = "Empresa de prueba";
            Comprobante.Emisor.DomicilioFiscal.calle = "Av. Paseo de la Reforma";
            Comprobante.Emisor.DomicilioFiscal.noExterior = "89";
            Comprobante.Emisor.DomicilioFiscal.noInterior = "103";
            Comprobante.Emisor.DomicilioFiscal.colonia = "Cuauhtemoc";
            Comprobante.Emisor.DomicilioFiscal.localidad = "Ciudad de Mexico";
            Comprobante.Emisor.DomicilioFiscal.municipio = "Cuauhtemoc";
            Comprobante.Emisor.DomicilioFiscal.estado = "Distrito Federal";
            Comprobante.Emisor.DomicilioFiscal.pais = "MEXICO";
            Comprobante.Emisor.DomicilioFiscal.codigoPostal = "06500";

            Comprobante.Emisor.ExpedidoEn.calle = "FRANCISCO PEREZ";
            Comprobante.Emisor.ExpedidoEn.noExterior = "35";
            Comprobante.Emisor.ExpedidoEn.noInterior = "1";
            Comprobante.Emisor.ExpedidoEn.colonia = "RICARDO FLORES MAGON";
            Comprobante.Emisor.ExpedidoEn.localidad = "VERACRUZ, VER.";
            Comprobante.Emisor.ExpedidoEn.municipio = "VERACRUZ";
            Comprobante.Emisor.ExpedidoEn.estado = "Veracruz";
            Comprobante.Emisor.ExpedidoEn.pais = "México";
            Comprobante.Emisor.ExpedidoEn.codigoPostal = "91900";

            //Llenado de datos del receptor
            Comprobante.Receptor.rfc = "FID080111867";
            Comprobante.Receptor.nombre = "FREIGHTIDEAS S.A DE C.V.";
            Comprobante.Receptor.Domicilio.calle = "ARIZONA";
            Comprobante.Receptor.Domicilio.noExterior = "108";
            //Comprobante.Receptor.Domicilio.noInterior = "1";
            Comprobante.Receptor.Domicilio.colonia = "COL. NAPOLES";
            //Comprobante.Receptor.Domicilio.localidad = "TEOLOYUCAN";
            Comprobante.Receptor.Domicilio.municipio = "Benito Juarez";
            Comprobante.Receptor.Domicilio.estado = "Distrito Federal";
            Comprobante.Receptor.Domicilio.pais = "MEXICO";
            Comprobante.Receptor.Domicilio.codigoPostal = "03810";


            //Crear un nuevo concepto
            FIGeneradorFacturaElectronica.Concepto Concepto1 = new FIGeneradorFacturaElectronica.Concepto();
            Concepto1.cantidad = 1;
            Concepto1.descripcion = "Software";
            Concepto1.valorUnitario = new FIGeneradorFacturaElectronica.Importe(1000);
            Concepto1.importe = new FIGeneradorFacturaElectronica.Importe(1000);
            //Concepto1.noIdentificacion = "PINO";
            //nuevo en los conceptos
            Concepto1.unidad = "Pieza";

            //ejemplo para agregar una cuenta predial al concepto
            //Concepto1.CuentaPredial="rur85859";

            //ejemplo para agregarle informacion aduanera en el concepto
            FIGeneradorFacturaElectronica.t_InformacionAduanera informacionAduanera=new t_InformacionAduanera();
            informacionAduanera.numero = "120";
            informacionAduanera.fecha = System.DateTime.Now;
            informacionAduanera.numero = "234";
            informacionAduanera.aduana = "AICM";

            Parte parte=new Parte();
            parte.InformacionAduanera.Add(informacionAduanera);
            parte.cantidad = 1;
            parte.descripcion = "Prueba";

            Concepto1.Parte.Add(parte);
            
            //crear otro concepto
             FIGeneradorFacturaElectronica.Concepto Concepto2 = new FIGeneradorFacturaElectronica.Concepto();
             Concepto2.cantidad=1;
             Concepto2.descripcion = "VALIDACION";
             Concepto2.valorUnitario=new FIGeneradorFacturaElectronica.Importe(100);
             Concepto2.importe = new FIGeneradorFacturaElectronica.Importe(100);
             Concepto2.unidad = "No aplica";

            //agregando complemento concepto al comprobante por order y cuenta de terceros
            AgregarComplementoterceros(Concepto2);

            //Agregando los conceptos al comprobante
            Comprobante.Conceptos.Add(Concepto1);
            Comprobante.Conceptos.Add(Concepto2);
            
            //totales de impuestos
            Comprobante.Impuestos.totalImpuestosRetenidos = new FIGeneradorFacturaElectronica.Importe(2317.44);
            Comprobante.Impuestos.totalImpuestosTrasladados = new FIGeneradorFacturaElectronica.Importe(176);

            //nuevo impuesto de tipo Traslado
            FIGeneradorFacturaElectronica.Traslado Traslado = new FIGeneradorFacturaElectronica.Traslado();
            Traslado.impuesto = FIGeneradorFacturaElectronica.Traslado.TipoImpuesto.IVA;
            Traslado.tasa = new FIGeneradorFacturaElectronica.Importe(16);
            Traslado.importe = new FIGeneradorFacturaElectronica.Importe(176);

            //agregar el impuesto 
            Comprobante.Impuestos.Traslados.Add(Traslado);


            //Nuevo impuesto tipo retencion
            FIGeneradorFacturaElectronica.Retencion Retencion = new FIGeneradorFacturaElectronica.Retencion();
            Retencion.impuesto = FIGeneradorFacturaElectronica.Retencion.TipoImpuesto.IVA;
            Retencion.importe = new FIGeneradorFacturaElectronica.Importe(2317.44);

            //agregar retencion
            Comprobante.Impuestos.Retenciones.Add(Retencion);

            //invocamos a la muestra de como crear complemento de impuestos locales
            AgregarComplementoImpuestosLocales(Comprobante);

            //nuevo objeto para la generacion del CFDI especificando el tipo
            FIGeneradorFacturaElectronica.Generador GenCFDI = new FIGeneradorFacturaElectronica.Generador(FIGeneradorFacturaElectronica.Generador.TipoFacturacion.CFDI);
            //Generar el nuevo comprobante y obtener el numero de errores
            List<String> Errores = GenCFDI.NuevoComprobante(Comprobante);

            //si el listado de errores es mayor a 1 quiere decir que existen un error y no puede generarse el preCFDI
            if(Errores.Count==0)
            {
                String PreCFDI=String.Empty;
                String ErroresPreCFDI = String.Empty;
                //generar el preCFDI si es correcto se regresa true y puede ahora timbrase
                if (GenCFDI.GenerarPreCFDI(PosicionCertificado + ArchivoKey, PosicionCertificado + ArchivoCertificado, ContraseñaCertificado,out PreCFDI,out ErroresPreCFDI))
                {
                    //Timbrando preCFDI
                    String CFDITimbrado = String.Empty;
                    //Conexion para timbrado
                    FIGeneradorFacturaElectronica.Timbre Timbrado = new FIGeneradorFacturaElectronica.Timbre();
                    //Si Timbrar devuelve true quiere decir que el timbre esta generado y podemos obtener las informacion del timbre de sus metodos
                    if (Timbrado.Timbrar(CodigoUsuarioProveedor, CodigoUsuario, IdSucursal, PreCFDI, Comprobante.total.Valor.ToString(), out CFDITimbrado,cbQR.Checked))
                    {
                        String XMLTimbre = Timbrado.XMLTimbre; //nuestro timbre generado
                        txtResultado.Text = CFDITimbrado; //nuestro CFDI ya timbrado
                        txtUUID.Text = Timbrado.UUID;
                        if (cbQR.Checked)
                            pbQR.Image = Timbrado.QRImagen; //imagen QR
                        lstErrores.Items.Clear();
                        lstErrores.Items.Add("Sin errores");
                    }
                    else
                    {
                            lstErrores.Items.Clear();
                            lstErrores.DataSource = Timbrado.Errores;
                            lstErrores.ValueMember = "Error";
                    }
                }
                else
                {
                    lstErrores.Items.Clear();
                    lstErrores.Items.Add(ErroresPreCFDI);
                }
            }
            else
            {
                lstErrores.Items.Clear();
                lstErrores.DataSource = Errores;
                
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(txtUUID.Text.Trim().Length>0)
            {
                //Conexion para timbrado
                FIGeneradorFacturaElectronica.Timbre Timbrado = new FIGeneradorFacturaElectronica.Timbre();
                //se envia a carcelar el timbre antes generado
                lblCancelar.Text = Timbrado.CancelarTimbre(CodigoUsuarioProveedor, CodigoUsuario, RFC,txtUUID.Text.Trim());

            }
        }

        private String AgregarComplementoImpuestosLocales(ComprobanteCFDI32 Comprobante)
        {
            //Codigo de ejemplo para crear complemento de impuestos locales

            FIGeneradorFacturaElectronica.Complementos.ImpuestosLocales ImpLoc=new FIGeneradorFacturaElectronica.Complementos.ImpuestosLocales();

            //Crear valores de impuesto local
            FIGeneradorFacturaElectronica.Complementos.TrasladosLocales TrasLoc = new TrasladosLocales();
            TrasLoc.ImpLocTrasladado = "ISH";
            TrasLoc.TasadeTraslado = new ImporteImpuestosLocales(10);
            TrasLoc.Importe = new ImporteImpuestosLocales(120.25);


            //Agregar el traslado
            ImpLoc.TrasladosLocales.Add(TrasLoc); 

            ImpLoc.TotaldeTraslados = new FIGeneradorFacturaElectronica.Complementos.ImporteImpuestosLocales(120.25);
            ImpLoc.TotaldeRetenciones=new FIGeneradorFacturaElectronica.Complementos.ImporteImpuestosLocales(0);

            String XMLImpuestosLoc = String.Empty;
            String Errores = String.Empty;
            
            if(!Comprobante.Complementos.AgregarComplemento(ImpLoc,out Errores))
                lstErrores.DataSource = Errores;
            return XMLImpuestosLoc;
        }

        private void AgregarComplementoterceros(Concepto cConcepto)
        {
            FIGeneradorFacturaElectronica.ComplementoConcepto.terceros Tercero=new terceros();
            Tercero.rfc = "FID080111867";
            Tercero.nombre = "FREIGHTIDEAS S.A DE C.V.";
            Tercero.InformacionFiscalTercero.calle = "ARIZONA";
            Tercero.InformacionFiscalTercero.noExterior = "108";
            //Comprobante.Receptor.Domicilio.noInterior = "1";
            Tercero.InformacionFiscalTercero.colonia = "COL. NAPOLES";
            //Comprobante.Receptor.Domicilio.localidad = "TEOLOYUCAN";
            Tercero.InformacionFiscalTercero.municipio = "Benito Juarez";
            Tercero.InformacionFiscalTercero.estado = "Distrito Federal";
            Tercero.InformacionFiscalTercero.pais = "MEXICO";
            Tercero.InformacionFiscalTercero.codigoPostal = "03810";

            Traslado TerceroTraslado=new Traslado();
            TerceroTraslado.impuesto = Traslado.TipoImpuesto.IVA;
            TerceroTraslado.tasa=new Importe(15);
            TerceroTraslado.importe=new Importe(15);

            Tercero.ImpuestosTerceros.Traslados.Add(TerceroTraslado);

            cConcepto.ComplementoConcepto = Tercero;
        }
    }
}
