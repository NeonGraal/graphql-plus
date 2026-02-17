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
  ItestCnstFieldDualDualObject? As_CnstFieldDualDual { get; }
}

public interface ItestCnstFieldDualDualObject
  : ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>
{
}

public interface ItestRefCnstFieldDualDual<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldDualDualObject<TRef>? As_RefCnstFieldDualDual { get; }
}

public interface ItestRefCnstFieldDualDualObject<TRef>
  : IGqlpModelImplementationBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstFieldDualDualObject? As_PrntCnstFieldDualDual { get; }
}

public interface ItestPrntCnstFieldDualDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  ItestAltCnstFieldDualDualObject? As_AltCnstFieldDualDual { get; }
}

public interface ItestAltCnstFieldDualDualObject
  : ItestPrntCnstFieldDualDualObject
{
  decimal Alt { get; }
}
