using series.Enum;
using System;

namespace series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {


            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        //ExcluirSerie();
                        break;
                    case "5":
                        //VizualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        break;
               
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar de séries");
            Console.WriteLine("2- Inseir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Vizualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void ListarSeries()
        {
            Console.WriteLine("listar série");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("nenhuma Série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));

                Console.WriteLine("#ID {0}: {1} ", serie.retornaId(), serie.retornaTitulo());
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} {1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            serie novaSerie = new serie(id: repositorio.ProximoId(),
                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

            //Insere as séries no repositório
            repositorio.Insere(novaSerie);
        }
         private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int IndiceSerie = int.Parse(Console.ReadLine());

            //Preparar informações para inserção
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            serie novaSerie = new serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
        }
         private static void ExcluirSerie()
        {

            Console.WriteLine("Informe a identificação da série para exclusão: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            //Melhoria futura: Inserir confirmação de exclusão para o usuário para que não ocorram exclusões errôneas
            repositorio.Exclui(indiceSerie);
 
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Informe a identificação da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RertonarPorId(indiceSerie);

            Console.WriteLine(serie);
        }

    }
}