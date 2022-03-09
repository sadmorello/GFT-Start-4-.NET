using static System.Console;

namespace Cadastro_de_Series
{
    class Program
    {
        static void Main(string[] args)
        {
            string option = GetOption();

            while (option.ToUpper() != "0")
            {
                switch (option)
                {
                    case "1":
                        ListSerie();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "6":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                option = GetOption();
            }

            WriteLine("Obrigado por utilizar nossos serviços.");
            ReadLine();
        }

        private static void DeleteSerie()
        {
            Write("Digite o id da série: ");
            repository.Delete(int.Parse(ReadLine()));
        }

        private static void ViewSerie()
        {
            Write("Digite o id da série: ");
            WriteLine(repository.RetornaPorId(int.Parse(ReadLine())));
        }

        private static void UpdateSerie()
        {
            Write("Digite o id da série: ");
            int idSerie = int.Parse(ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Write("Digite o gênero entre as opções acima: ");
            int newCategory = int.Parse(ReadLine());

            Write("Digite o Título da Série: ");
            string newTitle = ReadLine();

            Write("Digite o Ano de Início da Série: ");
            int newYear = int.Parse(ReadLine());

            Write("Digite a Descrição da Série: ");
            string newDesc = ReadLine();

            Serie updateSerie = new Serie(id: idSerie,
                                        genero: (Genero)newCategory,
                                        titulo: newTitle,
                                        ano: newYear,
                                        descricao: newDesc);

            repository.Update(idSerie, updateSerie);
        }
        private static void ListSerie()
        {
            WriteLine("Listar séries");

            var list = repository.List();

            if (list.Count == 0)
            {
                WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in list)
            {
                var D_E_L_E_T_ = serie.returnDelete();

                WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (D_E_L_E_T_ ? "*Excluído*" : ""));
            }
        }

        private static void InsertSerie()
        {
            WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Write("Digite o gênero entre as opções acima: ");
            int newCategory = int.Parse(ReadLine());

            Write("Digite o Título da Série: ");
            string newTitle = ReadLine();

            Write("Digite o Ano de Início da Série: ");
            int newYear = int.Parse(ReadLine());

            Write("Digite a Descrição da Série: ");
            string newDesc = ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(),
                                        category: (Category)newCategory,
                                        title: newTitle,
                                        year: newYear,
                                        description: newDesc);

            repository.Insere(newSerie);
        }

        private static string GetOption()
        {
            WriteLine(@"DIO Séries a seu dispor!!!
            Informe a opção desejada:
            1- Listar séries
            2- Inserir nova série
            3- Atualizar série
            4- Excluir série
            5- Visualizar série
            6- Limpar Tela
            0- Sair
            ");

            return ReadLine();
        }
    }
}
