namespace Series.src;

public class Serie : BaseEntiy
{
  private Genero Genero { get; set; }
  private string Title { get; set; }
  private string Description { get; set; }
  private int Year { get; set; }
  private bool Deleted { get; set; }

  public Serie(int id, Genero genero, string title, string description, int year)
  {
    this.Id = id;
    this.Genero = genero;
    this.Title = title;
    this.Description = description;
    this.Year = year;
    this.Deleted = false;
  }

  public override string ToString()
  {
    string response = "";
    response += "Genero: " + this.Genero + Environment.NewLine;
    response += "Título: " + this.Title + Environment.NewLine;
    response += "Descrição: " + this.Description + Environment.NewLine;
    response += "Ano de Início: " + this.Year + Environment.NewLine;
    response += "Excluido: " + this.Deleted + Environment.NewLine;

    return response;
  }

  public string getTitle()
  {
    return this.Title;
  }
  public int getId()
  {   
    return this.Id ;
  }
  public void Delete(){
    this.Deleted = true;
  }

  public bool getDeleted()
  {
    return this.Deleted;
  }
}