using System.Diagnostics.CodeAnalysis;

namespace GqlPlus;

public enum GqlpGeneratorType
{
  None,
  Stat,
  Intf,
  Enum,
  Impl,
  Test,

  Interface = Intf,
  Implementation = Impl,
  Static = Stat,
}
