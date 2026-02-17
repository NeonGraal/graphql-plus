//HintName: test_constraint-field-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

public interface ItestCnstFieldDualDual
  : ItestRefCnstFieldDualDual<ItestAltCnstFieldDualDual>
{
  ItestCnstFieldDualDualObject AsCnstFieldDualDual { get; }
}

public interface ItestCnstFieldDualDualObject
  : ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>
{
}

public interface ItestRefCnstFieldDualDual<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldDualDualObject<TRef> AsRefCnstFieldDualDual { get; }
}

public interface ItestRefCnstFieldDualDualObject<TRef>
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstFieldDualDualObject AsPrntCnstFieldDualDual { get; }
}

public interface ItestPrntCnstFieldDualDualObject
{
}

public interface ItestAltCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  ItestAltCnstFieldDualDualObject AsAltCnstFieldDualDual { get; }
}

public interface ItestAltCnstFieldDualDualObject
  : ItestPrntCnstFieldDualDualObject
{
  decimal Alt { get; }
}
