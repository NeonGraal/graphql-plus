using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal interface IGenerator<TAst>
  where TAst : IAstError
{
  void Generate(TAst ast, GqlpGeneratorContext context);
}
