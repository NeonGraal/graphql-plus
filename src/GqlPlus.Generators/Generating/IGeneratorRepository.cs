using System.Runtime.CompilerServices;
using GqlPlus.Ast;

namespace GqlPlus.Generating;

internal interface IGeneratorRepository
  : IRepository
{
  Generator<TAst>.D GeneratorFor<TAst>([CallerMemberName] string callerName = "")
    where TAst : IAstError;

  DeferList<ITypeGenerator>.D TypeGenerators(GqlpGeneratorType generatorType, [CallerMemberName] string callerName = "");
}
