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
  ItestRefCnstAltDualDual<ItestAltCnstAltDualDual> AsRefCnstAltDualDual { get; }
  ItestCnstAltDualDualObject AsCnstAltDualDual { get; }
}

public interface ItestCnstAltDualDualObject
{
}

public interface ItestRefCnstAltDualDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefCnstAltDualDualObject<TRef> AsRefCnstAltDualDual { get; }
}

public interface ItestRefCnstAltDualDualObject<TRef>
{
}

public interface ItestPrntCnstAltDualDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstAltDualDualObject AsPrntCnstAltDualDual { get; }
}

public interface ItestPrntCnstAltDualDualObject
{
}

public interface ItestAltCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
  ItestAltCnstAltDualDualObject AsAltCnstAltDualDual { get; }
}

public interface ItestAltCnstAltDualDualObject
  : ItestPrntCnstAltDualDualObject
{
  decimal Alt { get; }
}
