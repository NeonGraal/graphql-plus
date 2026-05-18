using GqlPlus.Ast;

namespace GqlPlus.Generating;

public interface IGenerator<TAst>
  where TAst : IAstError
{
  void Generate(TAst ast, GqlpGeneratorContext context);
}

internal class Generator<TAst>(
  Generator<TAst>.D factory
) : DeferOne<IGenerator<TAst>>(factory)
  , IGenerator<TAst>
  where TAst : IAstError
{
  public void Generate(TAst ast, GqlpGeneratorContext context)
    => Value.Generate(ast, context);

  public static implicit operator Generator<TAst>(D factory)
    => new(factory.ThrowIfNull());
}
