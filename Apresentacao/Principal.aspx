<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Apresentacao.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Cadastro de Clientes</h4>
            <br />
            <asp:MultiView ID="mvClientes" runat="server" ActiveViewIndex="1">
                <asp:View ID="vwCadastro" runat="server">
                    <br />
                    <asp:Button ID="btnVerListagem" runat="server" OnClick="btnVerListagem_Click" />
                    <br />
                    <table>
                        <tr>
                            <td>Cliente:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCliente" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>E-mail:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Status
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Sim" Selected="True" Value="S"></asp:ListItem>
                                    <asp:ListItem Text="Não" Value="N"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp
                            </td>
                            <td align="right">
                                <asp:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click"  />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="vwListagem" runat="server">
                    <br />
                    <asp:Button ID="btnVerCadastro" runat="server" Text="Ver cadastro" OnClick="btnVerCadastro_Click" />
                    <br />
                    <asp:GridView ID="grdClientes" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="grdClientes_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                            <asp:BoundField DataField="Email" HeaderText="E-mail" />
                            <asp:BoundField DataField="Ativo" HeaderText="Status" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DataCadastro" HeaderText="Data de Cadastro" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" />
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnEditar" runat="server" Text="Editar Cliente" OnClick="btnEditar_Click" 
                                        CommandArgument='<%# Eval("IdCliente") + "|" + Eval("Cliente") + "|" + Eval("Email") + "|" + Eval("Ativo") %>''/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir Cliente" OnClick="btnExcluir_Click" CommandArgument='<%# Eval("IdCliente") %>''/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                    <br />
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
