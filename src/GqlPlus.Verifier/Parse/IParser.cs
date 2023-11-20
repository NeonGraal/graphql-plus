namespace GqlPlus.Verifier.Parse;

public interface IParser<T>
{
  IResult<T> Parse(Tokenizer tokens);
}

public interface IParserArray<T>
{
  IResultArray<T> Parse(Tokenizer tokens);
}
