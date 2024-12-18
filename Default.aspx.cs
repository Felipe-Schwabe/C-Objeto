using Microsoft.Ajax.Utilities;
using Tutorial.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroClasse
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                preencherLista();
                CarregarDados();
                Session["guardarId"] = 0;
                linhaEditando = false;
                Session["guardarLinha"] = linhaEditando;
            }
        }
        bool linhaEditando;
        int Id = 0;
        int Codigo = 0;

        public void preencherLista()
        {
            DataSet ds = new DbConn().FillDataSet("SELECT * FROM Usuarios");
            foreach (DataRow dRow in ds.Tables[0].Rows)

            {
                Usuario usuario = new Usuario();
                usuario.Id = int.Parse(dRow["CódigoDoCliente"].ToString());
                usuario.Nome = dRow["Nome"].ToString();
                usuario.Email = dRow["Email"].ToString();
                usuario.Data = dRow["DataDeNascimento"].ToString();
                usuario.CPF = dRow["CPF"].ToString();
                usuario.Estado = dRow["Estado"].ToString();
                usuario.Cidade = dRow["Cidade"].ToString();
                usuario.Endereco = dRow["Endereço"].ToString();

                Usuario.listaUsuarios.Add(usuario);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {             
            linhaEditando = (bool)Session["guardarLinha"];

            if (linhaEditando == true)//editar usuario existente
            {
                if (txtNome.Text != "" && txtEmail.Text != "" && txtData.Text != "" && txtCPF.Text != "")
                {
                    int Id = (int)Session["guardarId"];
                    Usuario usuario = Usuario.listaUsuarios.FirstOrDefault(x => x.Id == Id);
                    if (Usuario.listaUsuarios != null && Id >= 0)
                    {
                        usuario.Nome = txtNome.Text;
                        usuario.Email = txtEmail.Text;
                        usuario.Data = txtData.Text;
                        usuario.CPF = txtCPF.Text;
                        usuario.Cidade = txtCidade.Text;
                        usuario.Estado = txtEstado.Text;
                        usuario.Endereco = txtEndereco.Text;


                        DbConn dbHnd = new DbConn();

                        DataSet ds = dbHnd.FillDataSet("SELECT * FROM Usuarios");

                        try

                        {

                            dbHnd.OpenConnection();

                            dbHnd.AddParameter("Nome", txtNome.Text);
                            dbHnd.AddParameter("Email", txtEmail.Text);
                            dbHnd.AddParameter("Data", txtData.Text);
                            dbHnd.AddParameter("CPF", txtCPF.Text);
                            dbHnd.AddParameter("Estado", txtEstado.Text);
                            dbHnd.AddParameter("Cidade", txtCidade.Text);
                            dbHnd.AddParameter("Endereco", txtEndereco.Text);

                            dbHnd.ExecuteNonQuery("UPDATE Usuarios SET Nome = @Nome, Email = @Email,DataDeNascimento = @Data,CPF = @CPF,Estado = @Estado,Cidade = @Cidade,Endereço = @Endereco WHERE CódigoDoCliente=" + Id);

                            dbHnd.CloseConnection();
                        }

                        finally

                        {
                            dbHnd.Dispose();
                        }

                        CarregarDados();
                    }
                
                    txtNome.Text = "";
                    txtEmail.Text = "";
                    txtData.Text = "";
                    txtCPF.Text = "";
                    txtEstado.Text = "";
                    txtCidade.Text = "";
                    txtEndereco.Text = "";

                    linhaEditando = false;
                    Session["guardarLinha"] = linhaEditando;
                    lblMensagem.Text = "<strong><font color=green> Cadastro atualizado com sucesso! </font> </strong>";
                }
                else
                {
                    lblMensagem.Text = "<strong><font color=red> PREENCHA OS CAMPOS OBRIGATÓRIOS </font> </strong>";
                }
            }
            else //criar um novo usuario
            {
                if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtData.Text) || string.IsNullOrEmpty(txtCPF.Text))
                {
                    lblMensagem.Text = "<strong><font color=red> PREENCHA OS CAMPOS OBRIGATÓRIOS </font> </strong>";
                    return;
                }

                DbConn dbHnd = new DbConn();
                try

                {

                    dbHnd.OpenConnection();

                    dbHnd.AddParameter("Nome", txtNome.Text);
                    dbHnd.AddParameter("Email", txtEmail.Text);
                    dbHnd.AddParameter("Data", txtData.Text);
                    dbHnd.AddParameter("CPF", txtCPF.Text);
                    dbHnd.AddParameter("Estado", txtEstado.Text);
                    dbHnd.AddParameter("Cidade", txtCidade.Text);
                    dbHnd.AddParameter("Endereco", txtEndereco.Text);

                    dbHnd.ExecuteNonQuery("INSERT INTO Usuarios (Nome, Email, DataDeNascimento , CPF, Estado, Cidade, Endereço) VALUES(@Nome, @Email, @Data, @CPF, @Estado, @Cidade, @Endereco)");

                    dbHnd.CloseConnection();

                }

                finally

                {
                    dbHnd.Dispose();
                }
                
                int Codigo = 0;
                var Nome = "";
                var Email = "";
                var Data = "";
                var CPF = "";
                var Estado = "";
                var Cidade = "";
                var Endereco = "";

                    DataSet ds = new DbConn().FillDataSet("SELECT * FROM Usuarios");
                    foreach (DataRow dRow in ds.Tables[0].Rows)

                    {

                        Codigo = int.Parse(dRow["CódigoDoCliente"].ToString());
                        Nome = dRow["Nome"].ToString();
                        Email = dRow["Email"].ToString();
                        Data = dRow["DataDeNascimento"].ToString();
                        CPF = dRow["CPF"].ToString();
                        Estado = dRow["Estado"].ToString();
                        Cidade = dRow["Cidade"].ToString();
                        Endereco = dRow["Endereço"].ToString();
                    }                     
                Usuario usuario = new Usuario();
                usuario.Nome = Nome;
                usuario.Email = Email;
                usuario.Data = Data;
                usuario.CPF = CPF;
                usuario.Cidade = Cidade;
                usuario.Estado = Estado;
                usuario.Endereco = Endereco;
                usuario.Id = Codigo;

                Usuario.listaUsuarios.Add(usuario);

                CarregarDados();

                txtNome.Text = "";
                txtEmail.Text = "";
                txtData.Text = "";
                txtCPF.Text = "";
                txtEstado.Text = "";
                txtCidade.Text = "";
                txtEndereco.Text = "";

                lblMensagem.Text = "<strong><font color=green> Cadastro criado com sucesso! </font> </strong>";
            }
        }

        protected void btnApagar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtData.Text = "";
            txtCPF.Text = "";
            txtEstado.Text = "";
            txtCidade.Text = "";
            txtEndereco.Text = "";

            lblMensagem.Text = "<strong><font color=gray> Rascunho apagado </font></strong>";
        }
        public void CarregarDados()
        {
            GridView1.DataSource = Usuario.listaUsuarios; 
            GridView1.DataBind();    
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            int Id = Convert.ToInt32(botao.CommandArgument);

            foreach (Usuario usuario in Usuario.listaUsuarios)
            {
                if (Id == usuario.Id)
                {
                    txtNome.Text = usuario.Nome;
                    txtEmail.Text = usuario.Email;
                    txtData.Text = usuario.Data;
                    txtCPF.Text = usuario.CPF;
                    txtEstado.Text = usuario.Estado;
                    txtCidade.Text = usuario.Cidade;
                    txtEndereco.Text = usuario.Estado;
                }
            }
            linhaEditando = true;
            Session["guardarLinha"] = linhaEditando;
            Session["guardarId"] = Id;
            Id = (int)Session["guardarId"];
            
        }
        protected void btnExcluir_Click1(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            int Codigo = Convert.ToInt32(botao.CommandArgument);
            Usuario usuario = Usuario.listaUsuarios.FirstOrDefault(x => x.Id == Codigo);
            DbConn dbHnd = new DbConn();
            try
            {
                DataSet ds = dbHnd.FillDataSet("SELECT * FROM Usuarios");
                dbHnd.OpenConnection();

                dbHnd.ExecuteNonQuery("DELETE FROM Usuarios WHERE CódigoDoCliente = " + Codigo);

                dbHnd.CloseConnection();
            }
            finally

            {
                dbHnd.Dispose();
            }
            if (usuario != null)
            {
                Usuario.listaUsuarios.Remove(usuario);

            }
            CarregarDados();
            lblMensagem.Text = "<strong><font color=red> O cadastro foi excluído </font> </strong>";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtData.Text = "";
            txtCPF.Text = "";
            txtEstado.Text = "";
            txtCidade.Text = "";
            txtEndereco.Text = "";
            linhaEditando = false;
            Session["guardarLinha"] = linhaEditando;
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            List<Usuario> nomesBuscar = new List<Usuario>();
            string textpesquisa = txtPesquisar.Text.Trim().ToLower();
            foreach (Usuario usuario in Usuario.listaUsuarios)
            {
                if (usuario.Nome.ToLower().Contains(textpesquisa))
                {
                    nomesBuscar.Add(usuario);
                    GridView1.DataSource = nomesBuscar;
                    GridView1.DataBind();
                    lblMensagem.Text = "<strong><font color=black> Exibindo os resultados... </font> </strong>";
                }
                else
                {
                    lblMensagem.Text = "<strong><font color=black> Exibindo os resultados... </font> </strong>";
                }
            }
            
        }

        protected void voltarbtn_Click(object sender, EventArgs e)
        {
            CarregarDados();
            txtPesquisar.Text = "";
        }

    }
}