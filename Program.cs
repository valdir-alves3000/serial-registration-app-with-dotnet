namespace Series.src;
using static System.Console;

class Program
{
  static SerieRepository serieRepository = new SerieRepository();
   static void Main(string[] args)
  { 
    string userOption = GetUserOption();

    while (userOption.ToUpper() != "X")
    {
      switch (userOption)
      {
        case "1":
          ListSeries();
          break;        
        case "2":
          InsertSerie();
          break;        
        case "3":
          break;        
        case "4":
          break;        
        case "5":
          break;        
        case "C":
          break;        
        default:
        throw new ArgumentOutOfRangeException();
      }
      userOption = GetUserOption();
    }

    WriteLine("Obrigado por utilizar nossos serviços.");
  }

  private static void ListSeries()
  {
    WriteLine("Listar séries");

    var listSeries = serieRepository.ListAll();

    if(listSeries.Count == 0)
    {
      WriteLine("Nenhuma série cadastrada.");
      return;
    }

    foreach (var serie in listSeries)
    {
      WriteLine("#ID {0}: - {1}",serie.getId(),serie.getTitle());
    }
  }

private static async void InsertSerie()
{
  WriteLine("Inserir nova série");

  foreach (int i in Enum.GetValues(typeof(Genero)))
  {
    WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
  }

  Write("Digite o gênero entre as opções acima: ");
  int inputGenero = int.Parse(ReadLine());

  Write("Digite o Título da Série: ");
  string inputTitle = ReadLine();

  Write("Digite o Ano de Início da Série: ");
  int inputYear = int.Parse(ReadLine());

  Write("Digite a Descrição da Série: ");
  string inputDescription = ReadLine();

  Serie newSerie = new Serie(id: serieRepository.NextId(), genero: (Genero)inputGenero,title: inputTitle, year: inputYear,
  description: inputDescription);

  serieRepository.Insert(newSerie);
}
  private static string GetUserOption()
  {
    WriteLine();
    WriteLine("DIO Séries ao seu dispor!!!");
    WriteLine("Informe a opção desejada: ");

    WriteLine("1 - Listar séries");
    WriteLine("2 - Inserir série");
    WriteLine("3 - Atualizar série ");
    WriteLine("4 - Excluir série");
    WriteLine("5 - Visualizar série");
    WriteLine("C - Limpar tela");
    WriteLine("X - Sair");
    WriteLine();

    string userOption = ReadLine().ToUpper();
    WriteLine();

    return userOption;
  }
}
