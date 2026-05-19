namespace GqlPlus.Schema.Modelling;

internal sealed class SchSchemaImplementation(
  ICollection<string> description,
  ISch_Name name,
  IDictionary<ISch_Name, ISch_Categories>? categories,
  IDictionary<ISch_Name, ISch_Directives>? directives,
  IDictionary<ISch_Name, ISch_Type>? types,
  IDictionary<ISch_Name, ISch_Setting>? settings
) : ISch_SchemaObject
{
  public ICollection<string> Description { get; } = description;

  public ISch_Name Name { get; } = name;

  public IDictionary<ISch_Name, ISch_Categories>? Categories(ISch_CategoryFilter? parameter) => categories;

  public IDictionary<ISch_Name, ISch_Categories>? Categories() => categories;

  public IDictionary<ISch_Name, ISch_Directives>? Directives(ISch_Filter? parameter) => directives;

  public IDictionary<ISch_Name, ISch_Directives>? Directives() => directives;

  public IDictionary<ISch_Name, ISch_Type>? Types(ISch_TypeFilter? parameter) => types;

  public IDictionary<ISch_Name, ISch_Type>? Types() => types;

  public IDictionary<ISch_Name, ISch_Setting>? Settings(ISch_Filter? parameter) => settings;

  public IDictionary<ISch_Name, ISch_Setting>? Settings() => settings;
}
