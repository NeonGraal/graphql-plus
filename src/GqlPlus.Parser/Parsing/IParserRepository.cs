namespace GqlPlus.Parsing;

public interface IParserRepository
{
  [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Get is the standard repository pattern method name")]
  Parser<T>.L Get<T>();
  Parser<T>.LA GetArray<T>();
  Parser<TInterface, T>.L GetInterface<TInterface, T>()
    where TInterface : class, Parser<T>.I;
  ParserArray<TInterface, T>.LA GetArrayInterface<TInterface, T>()
    where TInterface : class, Parser<T>.IA;
}
