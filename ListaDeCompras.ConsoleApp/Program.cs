using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloListaDeCompra;
using ListaDeCompras.ConsoleApp.Utilidades;

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    ITela? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();

        if (opcaoSubMenu == "S")
        {
            Console.Clear();
            break;
        }
        if (telaSelecionada is TelaBase telaBase)
        {
            if (opcaoSubMenu == "1")
                telaBase.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaBase.Editar();

            else if (opcaoSubMenu == "3")
                telaBase.Excluir();

            else if (opcaoSubMenu == "4")
                telaBase.VisualizarTodos(deveExibirCabecalho: true);
        }
        if (telaSelecionada is TelaAdicionarLista telaAdd)
        {
            if (opcaoSubMenu == "1")
                telaAdd.CadastrarProduto();
            if (opcaoSubMenu == "2")
                telaAdd.ExcluirProduto();
        }
    }
}