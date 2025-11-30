namespace GqlPlus.Convert;

public class ConvertTestsBase(IConvertTestsBase converters)
{
  protected IConvertTestsBase Converters { get; } = converters;
}

public interface IConvertTestsBase
{
  string[] ConvertTo(Structured model);
  Structured ConvertFrom(string[] input);
}
