namespace GqlPlus.Convert;

public class ConvertTestsBase(IConvertTestsBase converters)
{
  protected IConvertTestsBase Converters { get; } = converters;
}

public interface IConvertTestsBase
{
  string[] ConvertTo(IGqlpValue model);
  IGqlpValue ConvertFrom(string[] input);
}
