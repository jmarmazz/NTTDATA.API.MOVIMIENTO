

using System;

namespace NTTDATA.DOMAIN.Constants
{
    public static class DomainConstants
    {
        public const string ERRORCLIENTE_SOLICITUDINVALIDA = "C01";
        public const string ERRORCLIENTE_EXISTENTE = "C02";
        public const string ERRORCLIENTE_CUENTAEXISTENTE = "C03";

        public static short ObtenerHttpStatusCode(string CodigoError)
        {
            if (string.IsNullOrEmpty(CodigoError))
            {
                return 200;
            }

            switch (CodigoError)
            {
                case ERRORCLIENTE_SOLICITUDINVALIDA:
                case ERRORCLIENTE_EXISTENTE:
                case ERRORCLIENTE_CUENTAEXISTENTE:
                    return 400; 
                default:
                        return 500;
            }
        }
    }
}
