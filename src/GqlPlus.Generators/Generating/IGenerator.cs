using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal interface IGenerator<TAst>
  where TAst : IGqlpError
{
  void Generate(TAst ast, GqlpGeneratorContext context);
}
