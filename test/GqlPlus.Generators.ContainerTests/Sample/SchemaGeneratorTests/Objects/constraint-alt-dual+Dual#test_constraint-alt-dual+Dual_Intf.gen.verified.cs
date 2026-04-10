//HintName: test_constraint-alt-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public interface ItestCnstAltDualDual
  : IGqlpInterfaceBase
{
  ItestRefCnstAltDualDual<ItestAltCnstAltDualDual>? AsRefCnstAltDualDual { get; }
  ItestCnstAltDualDualObject? As_CnstAltDualDual { get; }
}

public interface ItestCnstAltDualDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltDualDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDualDualObject<TRef>? As_RefCnstAltDualDual { get; }
}

public interface ItestRefCnstAltDualDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstAltDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstAltDualDualObject? As_PrntCnstAltDualDual { get; }
}

public interface ItestPrntCnstAltDualDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
  ItestAltCnstAltDualDualObject? As_AltCnstAltDualDual { get; }
}

public interface ItestAltCnstAltDualDualObject
  : ItestPrntCnstAltDualDualObject
{
  decimal Alt { get; }
}
