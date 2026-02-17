//HintName: test_constraint-alt-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public interface ItestCnstAltDualDual
  : IGqlpModelImplementationBase
{
  ItestRefCnstAltDualDual<ItestAltCnstAltDualDual>? AsRefCnstAltDualDual { get; }
  ItestCnstAltDualDualObject? As_CnstAltDualDual { get; }
}

public interface ItestCnstAltDualDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstAltDualDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDualDualObject<TRef>? As_RefCnstAltDualDual { get; }
}

public interface ItestRefCnstAltDualDualObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestPrntCnstAltDualDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstAltDualDualObject? As_PrntCnstAltDualDual { get; }
}

public interface ItestPrntCnstAltDualDualObject
  : IGqlpModelImplementationBase
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
