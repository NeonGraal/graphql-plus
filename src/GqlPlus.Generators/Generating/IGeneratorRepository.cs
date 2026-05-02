using System.Runtime.CompilerServices;
using GqlPlus.Ast;

namespace GqlPlus.Generating;

internal interface IGeneratorRepository
{
  IGenerator<TAst> GeneratorFor<TAst>([CallerMemberName] string callerName = "")
    where TAst : IAstError;

  IEnumerable<ITypeGenerator> TypeGenerators(GqlpGeneratorType generatorType, [CallerMemberName] string callerName = "");
}
