using System.Runtime.CompilerServices;

namespace GqlPlus;

internal sealed class ModuleInitializer
{
  [ModuleInitializer]
  public static void Init()
    => VerifySourceGenerators.Initialize();
}
