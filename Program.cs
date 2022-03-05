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
          UpdateSerie();
          break;        
        case "4":
          DeleteSerie();
          break;        
        case "5":
          getByIdSerie();
          break;        
        case "C":
          Console.Clear();
          break;        
        default:
        throw new ArgumentOutOfRangeException();
      }
      userOption = GetUserOption();
    }

    WriteLine("Obrigado por utilizar nossos serviços.");
  }

  private static Serie Data(int indiceSerie){

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

    Serie response = new Serie(id: indiceSerie, genero: (Genero)inputGenero,title: inputTitle, year: inputYear,
    description: inputDescription);

    return response;
  }

 private static int InputId()
 {
  Write("Digite o ID da série: ");
  int indiceSerie = int.Parse(ReadLine());
      
  return indiceSerie;
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
      var deleted = serie.getDeleted();
      if(!deleted)
      {
        WriteLine("#ID {0}: - {1}",serie.getId(),serie.getTitle());
      }
    }
  }

  private static void InsertSerie()
  {
    WriteLine("Inserir nova série");
    int indiceSerie = serieRepository.NextId();

    Serie newSerie =  Data(indiceSerie);
    serieRepository.Insert(newSerie);
  }

  private static void UpdateSerie()
  {
    int inputId = InputId();
    
    Serie updateSerie = Data(inputId);
    serieRepository.Update(inputId, updateSerie);
  }

  private static void DeleteSerie()
  {
    int inputId = InputId();   
    
    serieRepository.Delete(inputId);
  }

  private static void getByIdSerie()
  {
    int inputId = InputId();

    WriteLine(serieRepository.getById(inputId));
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
