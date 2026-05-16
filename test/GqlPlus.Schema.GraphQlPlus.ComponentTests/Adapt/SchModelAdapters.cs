using GqlPlus.Schema;

namespace GqlPlus.Adapt;

internal sealed class SchSchemaAdapter(SchemaModel model)
  : ISch_SchemaObject
{
  public ICollection<string> Description
    => string.IsNullOrEmpty(model.Description) ? [] : [model.Description];

  public ISch_Name Name { get; } = MakeName(model.Name);

  private static Sch_Name MakeName(string name)
  {
    Sch_Name n = new();
    n.SetValue(name);
    return n;
  }

  public IDictionary<ISch_Name, ISch_Categories>? Categories(ISch_CategoryFilter? parameter) => null;
  public IDictionary<ISch_Name, ISch_Categories>? Categories() => null;
  public IDictionary<ISch_Name, ISch_Directives>? Directives(ISch_Filter? parameter) => null;
  public IDictionary<ISch_Name, ISch_Directives>? Directives() => null;
  public IDictionary<ISch_Name, ISch_Type>? Types(ISch_TypeFilter? parameter) => null;
  public IDictionary<ISch_Name, ISch_Type>? Types() => null;
  public IDictionary<ISch_Name, ISch_Setting>? Settings(ISch_Filter? parameter) => null;
  public IDictionary<ISch_Name, ISch_Setting>? Settings() => null;
}
