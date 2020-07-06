using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using Modelo;


namespace Negocio
{
    public class MGClientes
    {
        DSClientes dadosClientes = new DSClientes();

        public void InserirClientes(MLClientes modelo)
        {
            dadosClientes.InserirClientes(modelo);
        }

        public void AtualizarClientes(MLClientes modelo)
        {
            dadosClientes.AtualizarClientes(modelo);
        }

        public void ExcluirClientes(int IdCliente)
        {
            dadosClientes.ExcluirClientes(IdCliente);
        }

        public List<MLClientes> ListarClientes()
        {
            var listaRetorno = dadosClientes.listarClientes();
            if (listaRetorno != null && listaRetorno.Count > 0)
            {
                foreach (var item in listaRetorno)
                {
                    TimeSpan ts = DateTime.Now - item.DataCadastro;
                    int dias = ts.Days;
                    if (dias > 30 && dias <= 179)
                        item.TipoCliente = "Prata";
                    else if (dias > 180 && dias <= 364)
                        item.TipoCliente = "Ouro";
                    else if (dias > 365)
                        item.TipoCliente = "Platina";
                    else
                        item.TipoCliente = "Bronze";



                }
            }

            return listaRetorno;
        }
    }
}
