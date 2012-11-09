using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FIGeneradorFacturaElectronica;

namespace EjemploTimbrarCFDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Datos Certificado
        private String ArchivoKey = "aaqm610917qja_1011180955s.key";
        private String ArchivoCertificado = "aaqm610917qja.cer";
        private String ContraseñaCertificado = "12345678a";
        private String NoCertificado = "20001000000100001695";
        private String PosicionCertificado = "D:\\Certificados\\";

        //datos Timbre
        private String CodigoUsuarioProveedor = "N#@Mo!)#oh>)BYOdX=q_ZUCsLxqpv?";
        private String CodigoUsuario = "1763AAB0593430490B3B3EE5457A9A2580F9D7DE";
        private int IdSucursal = 33928;

        private void btnTimbrar_Click(object sender, EventArgs e)
        {
            //crear un nuevo comprobante CFDI para la version 3.2
            FIGeneradorFacturaElectronica.ComprobanteCFDI32 Comprobante=new ComprobanteCFDI32();
            Comprobante.serie = "VER";
            Comprobante.folio = "8823"; //dato no obligatorio
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
            Comprobante.Emisor.rfc = "AAQM610917QJA";
            Comprobante.Emisor.nombre = "Empresa de prueba";
            Comprobante.Emisor.DomicilioFiscal.calle = "Av. Paseo de la Reforma";
            Comprobante.Emisor.DomicilioFiscal.noExterior = "389";
            Comprobante.Emisor.DomicilioFiscal.noInterior = "Piso 18 Altos 1001";
            Comprobante.Emisor.DomicilioFiscal.colonia = "Cuauhtemoc";
            Comprobante.Emisor.DomicilioFiscal.localidad = "Ciudad de Mexico";
            Comprobante.Emisor.DomicilioFiscal.municipio = "Cuauhtemoc";
            Comprobante.Emisor.DomicilioFiscal.estado = "Distrito Federal";
            Comprobante.Emisor.DomicilioFiscal.pais = "MEXICO";
            Comprobante.Emisor.DomicilioFiscal.codigoPostal = "06500";

            Comprobante.Emisor.ExpedidoEn.calle = "ALICIO PEREZ";
            Comprobante.Emisor.ExpedidoEn.noExterior = "25";
            Comprobante.Emisor.ExpedidoEn.noInterior = "4";
            Comprobante.Emisor.ExpedidoEn.colonia = "RICARDO FLORES MAGON";
            Comprobante.Emisor.ExpedidoEn.localidad = "VERACRUZ, VER.";
            Comprobante.Emisor.ExpedidoEn.municipio = "VERACRUZ";
            Comprobante.Emisor.ExpedidoEn.estado = "Veracruz";
            Comprobante.Emisor.ExpedidoEn.pais = "México";
            Comprobante.Emisor.ExpedidoEn.codigoPostal = "91900";

            //Llenado de datos del receptor
            Comprobante.Receptor.rfc = "QDE740215PF3";
            Comprobante.Receptor.nombre = "QUIMICA DELTA S.A DE C.V";
            Comprobante.Receptor.Domicilio.calle = "CARRETERA TEOLOYUCAN-HUEHUETOCA";
            Comprobante.Receptor.Domicilio.noExterior = "259";
            Comprobante.Receptor.Domicilio.noInterior = "AREA 1";
            Comprobante.Receptor.Domicilio.colonia = "COL. BARRIO SANTA MARIA CALIACAC";
            //Comprobante.Receptor.Domicilio.localidad = "TEOLOYUCAN";
            Comprobante.Receptor.Domicilio.municipio = "TEOLOYUCAN";
            Comprobante.Receptor.Domicilio.estado = "ESTADO DE MEXICO";
            Comprobante.Receptor.Domicilio.pais = "MEXICO";
            Comprobante.Receptor.Domicilio.codigoPostal = "54770";


            //Crear un nuevo concepto
            FIGeneradorFacturaElectronica.Concepto Concepto1 = new FIGeneradorFacturaElectronica.Concepto();
            Concepto1.cantidad = 1;
            Concepto1.descripcion = "REVALIDACION EN PUERTO";
            Concepto1.valorUnitario = new FIGeneradorFacturaElectronica.Importe(1000);
            Concepto1.importe = new FIGeneradorFacturaElectronica.Importe(1000);
            //Concepto1.noIdentificacion = "PINO";
            //nuevo en los conceptos
            Concepto1.unidad = "No aplica";

            //crear otro concepto
             FIGeneradorFacturaElectronica.Concepto Concepto2 = new FIGeneradorFacturaElectronica.Concepto();
             Concepto2.cantidad=1;
             Concepto2.descripcion = "VALIDACION";
             Concepto2.valorUnitario=new FIGeneradorFacturaElectronica.Importe(100);
             Concepto2.importe = new FIGeneradorFacturaElectronica.Importe(100);
             Concepto2.unidad = "No aplica";

            //Agregando los conceptos al comprobante
            Comprobante.Conceptos.Add(Concepto1);
            Comprobante.Conceptos.Add(Concepto2);

            //totales de impuestos
            Comprobante.Impuestos.totalImpuestosRetenidos = new FIGeneradorFacturaElectronica.Importe(0);
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
            //Comprobante.Impuestos.Retenciones.Add(Retencion);

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
                    if (Timbrado.Timbrar(CodigoUsuarioProveedor, CodigoUsuario, IdSucursal, PreCFDI, Comprobante.total.Valor.ToString(), out CFDITimbrado))
                    {
                        String XMLTimbre = Timbrado.XMLTimbre; //nuestro timbre generado
                        txtResultado.Text = CFDITimbrado; //nuestro CFDI ya timbrado
                        pbQR.Image = Timbrado.QRImagen; //imagen QR
                        lstErrores.Items.Clear();
                        lstErrores.Items.Add("Sin errores");
                    }
                    else
                    {
                        lstErrores.Items.Clear();
                        lstErrores.Items.Add(CFDITimbrado);
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
                
            }


        }
    }
}
