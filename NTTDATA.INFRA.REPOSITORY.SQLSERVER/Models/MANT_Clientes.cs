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
        internal void RegistrarCliente(Cliente cliente, byte accion)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@p" + param.Count, accion));
            param.Add(new SqlParameter("@p"+ param.Count, cliente.IdCliente));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Nombre ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Identificacion ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Clave ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Genero));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Edad));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Direccion ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Telefono ?? ""));
            param.Add(new SqlParameter() { ParameterName = "@p" + param.Count, SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output });
            string commandText = "MANT_Clientes ";
            for (var i = 0; i < param.Count - 1; i++) commandText += $"@p{i},";
            commandText += $"@p{param.Count - 1} OUTPUT";
            Database.ExecuteSqlRaw(commandText, param);
            var resp = Convert.ToInt32(param.Last().Value); 
        }
    }
}
