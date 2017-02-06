using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WASS_SAPTFI.Controllers.Calculos
{
    public class Ley24241:CalculoStrategy
    {
        public override DatosCalculo RealizarCalculo(DatosCalculo pDatos)
        {

            pDatos.txtPrestacionCompensatoria = CalcularPC(pDatos);
            pDatos.txtPap = CalcularPAP(pDatos);
            return pDatos;

        }



        //Calcular Prestación Compensatoria
        private string CalcularPC(DatosCalculo pDatos)
        {

            if (pDatos.PCm != 0 || pDatos.PCn != 0 || pDatos.PCp != 0)
            {
                pDatos.PC = (Convert.ToDecimal(0.015) * pDatos.PCN) * (((pDatos.PCn + pDatos.PCp) * pDatos.PCW + (pDatos.PCm + pDatos.PCp) * pDatos.PCR) / (pDatos.PCn + pDatos.PCm + pDatos.PCp));


                pDatos.PC = Decimal.Round(pDatos.PC, 2);
                pDatos.txtPrestacionCompensatoria = "$ " + pDatos.PC.ToString();
                return pDatos.txtPrestacionCompensatoria;
            }
            else
            {
                throw new Exception("Meses RD = 0. \tMeses AU = 0. \tMeses simultáneos =0. \n\nAlguno de estos campos debe ser distinto de 0. \nSe requiere corregir este error antes de volver a realizar el cálculo.");

            }
        }

        //Calcular Prestación Adicional por Permanencia
        private string CalcularPAP(DatosCalculo pDatos)
        {


            if (pDatos.PAPm != 0 || pDatos.PAPn != 0 || pDatos.PAPp != 0)
            {
                pDatos.PAP = (Convert.ToDecimal(0.015) * pDatos.PAPN) * (((pDatos.PAPn + pDatos.PAPp) * pDatos.PAPW + (pDatos.PAPm + pDatos.PAPp) * pDatos.PAPR) / (pDatos.PAPn + pDatos.PAPm + pDatos.PAPp));


                pDatos.PAP = Decimal.Round(pDatos.PAP, 2);
                pDatos.txtPap = "$ " + pDatos.PAP.ToString();
                return pDatos.txtPap;
            }
            else
            {
                throw new Exception("Meses RD = 0. \tMeses AU = 0. \tMeses simultáneos =0. \n\nAlguno de estos campos debe ser distinto de 0. \nSe requiere corregir este error antes de volver a realizar el cálculo.");
            }

        }
    }
}