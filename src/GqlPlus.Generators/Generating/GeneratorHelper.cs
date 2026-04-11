using GqlPlus.Ast;

namespace GqlPlus.Generating;

internal static class GeneratorHelper
{
  internal static void Generate<TAst>(this IEnumerable<TAst> asts, IGenerator<TAst> generator, GqlpGeneratorContext context)
    where TAst : IAstError
  {
    asts.ThrowIfNull();

    foreach (TAst ast in asts) {
      generator?.Generate(ast, context);
    }
  }
}
