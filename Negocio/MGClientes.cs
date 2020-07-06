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
            return dadosClientes.listarClientes();
        }
    }
}
