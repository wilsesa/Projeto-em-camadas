using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Negocio;

namespace Apresentacao
{
    public partial class Principal : System.Web.UI.Page
    {
        MGClientes negocioClientes = new MGClientes();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.PopularGrid();
        }

        #region Métodos

        public void AtualizarClientes(MLClientes modelo)
        {
            negocioClientes.AtualizarClientes(modelo);
        }
        public void ExcluirCliente(int IdCliente)
        {
            negocioClientes.ExcluirClientes(IdCliente);
            this.PopularGrid();
        }
        public void GravarClientes(MLClientes modelo)
        {
            negocioClientes.InserirClientes(modelo);
        }
        public void PopularGrid()
        {
            var listaRetorno = negocioClientes.ListarClientes();
            grdClientes.DataSource = listaRetorno != null ? listaRetorno : null;
            grdClientes.DataBind();
        }
        #endregion

        #region Eventos
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            var arrayAuxiliar = btnEditar.CommandArgument.Split('|');
            vwIdCliente = Convert.ToInt32(arrayAuxiliar[0].ToString());
            txtCliente.Text = arrayAuxiliar[1].ToString();
            txtEmail.Text = arrayAuxiliar[2].ToString();
            rblStatus.SelectedValue = arrayAuxiliar[3].ToString().Equals("Sim") ? "S" : "N";

            mvClientes.ActiveViewIndex = 0;
        }
        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            Button btnExcluir = (Button)sender;
            var idCliente = Convert.ToInt32(btnExcluir.CommandArgument);
            this.ExcluirCliente(idCliente);
        }
        protected void btnGravar_Click(object sender, EventArgs e)
        {
            var modeloClientes = new MLClientes() { IdCliente = vwIdCliente, Cliente = txtCliente.Text, Email = txtEmail.Text,
                Ativo = rblStatus.SelectedValue.Equals("S"), DataCadastro = DateTime.Now };

            if (vwIdCliente > 0)
               this.AtualizarClientes(modeloClientes);
            else
                this.GravarClientes(modeloClientes);

            mvClientes.ActiveViewIndex = 1;
            this.PopularGrid();
        }
        protected void btnVerListagem_Click(object sender, EventArgs e)
        {
            this.PopularGrid();
            mvClientes.ActiveViewIndex = 1;

        }
        protected void btnVerCadastro_Click(object sender, EventArgs e)
        {
            mvClientes.ActiveViewIndex = 0;
        }
        protected void grdClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = e.Row.Cells[2].Text.Equals("True") ? "Sim" : "Não";
                //if (e.Row.Cells[2].Text.Equals("True"))
                //    e.Row.Cells[2].Text = "Sim";
                //else
                //    e.Row.Cells[2].Text = "Nao";
            }
        }
        protected int vwIdCliente 
        {
            get
            {
                int idRetorno = 0;
                if (ViewState["IdCliente"] != null)
                    idRetorno = Convert.ToInt32(ViewState["IdCliente"]);
                return idRetorno;
            }
            set
            {
                ViewState["IdCliente"] = value;
            }
        }
        #endregion
        protected void grdClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClientes.PageIndex = e.NewPageIndex;
            this.PopularGrid();
        }
        
    }
}