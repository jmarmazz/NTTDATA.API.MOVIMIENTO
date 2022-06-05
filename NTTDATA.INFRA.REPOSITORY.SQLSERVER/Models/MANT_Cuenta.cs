using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NTTDATA.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NTTDATA.INFRA.REPOSITORY.SQLSERVER.Models
{
    public sealed partial class CmdContext
    {
        internal void RegistrarCuenta(Cuenta cuenta, byte accion)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@p" + param.Count, accion));
            param.Add(new SqlParameter("@p"+ param.Count, cuenta.IdCuenta));
            param.Add(new SqlParameter("@p" + param.Count, cuenta.IdCliente));
            param.Add(new SqlParameter("@p" + param.Count, cuenta.NumeroCuenta ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cuenta.TipoCuenta));
            param.Add(new SqlParameter("@p" + param.Count, cuenta.SaldoInicial)); 
            param.Add(new SqlParameter() { ParameterName = "@p" + param.Count, SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output });
            string commandText = "MANT_Cuentas ";
            for (var i = 0; i < param.Count - 1; i++) commandText += $"@p{i},";
            commandText += $"@p{param.Count - 1} OUTPUT";
            Database.ExecuteSqlRaw(commandText, param);
            var resp = Convert.ToInt32(param.Last().Value); 
        }
    }
}
