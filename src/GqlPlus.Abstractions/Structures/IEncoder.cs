namespace GqlPlus.Structures;

public interface IEncoder<TModel>
{
  Structured Encode(TModel model);
}
