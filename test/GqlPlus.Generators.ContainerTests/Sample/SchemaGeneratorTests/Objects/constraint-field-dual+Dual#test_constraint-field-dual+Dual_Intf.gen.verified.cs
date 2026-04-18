//HintName: test_constraint-field-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldDualDualObject<TRef>? As_RefCnstFieldDualDual { get; }
}

public interface ItestRefCnstFieldDualDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstFieldDualDualObject? As_PrntCnstFieldDualDual { get; }
}

public interface ItestPrntCnstFieldDualDualObject
  : IGqlpInterfaceBase
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
