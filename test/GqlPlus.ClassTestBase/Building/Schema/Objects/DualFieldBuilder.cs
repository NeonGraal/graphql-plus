using GqlPlus.Abstractions.Schema;
using NSubstitute.Core;

namespace GqlPlus.Building.Schema.Objects;

public class DualFieldBuilder
  : ObjFieldBuilder
{
  public DualFieldBuilder(string name, string type)
    : base(name, type)
    => Add<IGqlpDualField>();

  public IGqlpDualField AsDualField
    => Build<IGqlpDualField>();
}
