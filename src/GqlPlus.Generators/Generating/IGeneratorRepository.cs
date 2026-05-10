using System.Runtime.CompilerServices;
using GqlPlus.Ast;

namespace GqlPlus.Generating;

internal interface IGeneratorRepository
  : IRepository
{
  Defer<IGenerator<TAst>>.D GeneratorFor<TAst>([CallerMemberName] string callerName = "")
    where TAst : IAstError;

  Defer<ITypeGenerator>.DA TypeGenerators(GqlpGeneratorType generatorType, [CallerMemberName] string callerName = "");
}
