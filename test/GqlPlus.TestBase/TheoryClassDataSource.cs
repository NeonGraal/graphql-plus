using AutoFixture.Xunit3.Internal;
using Xunit;

namespace GqlPlus;

internal class TheoryClassDataSource(
  Type type,
  object[] parameters
) : DataSource
{
  private readonly object[] _parameters = parameters;

  public Type Type { get; } = type;

  public IReadOnlyList<object> Parameters => Array.AsReadOnly(_parameters);

  protected override IEnumerable<object[]> GetData()
  {
    object? instance = Activator.CreateInstance(type: Type, args: _parameters);
    if (instance is not IReadOnlyCollection<ITheoryDataRow> enumerable) {
      throw new InvalidOperationException($"Data source type \"{Type}\" should implement the \"{typeof(IReadOnlyCollection<ITheoryDataRow>)}\" interface.");
    }

    return enumerable.Select(ConvertRow);

    static object[] ConvertRow(ITheoryDataRow row)
      => [.. row.GetData().Cast<object>()];
  }
}
