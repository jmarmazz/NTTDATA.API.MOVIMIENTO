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
        internal void RegistrarMovimiento(Movimiento movimiento, byte accion)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@p" + param.Count, accion));
            param.Add(new SqlParameter("@p"+ param.Count, movimiento.IdMovimiento));
            param.Add(new SqlParameter("@p" + param.Count, movimiento.NumeroCuenta ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, movimiento.TipoMovimiento));
            param.Add(new SqlParameter("@p" + param.Count, movimiento.Descripcion ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, movimiento.Valor));
            param.Add(new SqlParameter() { ParameterName = "@p" + param.Count, SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output });
            string commandText = "TRANS_Movimientos ";
            for (var i = 0; i < param.Count - 1; i++) commandText += $"@p{i},";
            commandText += $"@p{param.Count - 1} OUTPUT";
            Database.ExecuteSqlRaw(commandText, param);
            var resp = Convert.ToInt32(param.Last().Value); 
        }
    }
}
