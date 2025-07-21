using System.Diagnostics.CodeAnalysis;

namespace GqlPlus;

[SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix")]
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
