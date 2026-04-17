//HintName: test_constraint-parent-dual-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

public interface ItestCnstPrntDualPrntDual
  : ItestRefCnstPrntDualPrntDual<ItestAltCnstPrntDualPrntDual>
{
  ItestCnstPrntDualPrntDualObject? As_CnstPrntDualPrntDual { get; }
}

public interface ItestCnstPrntDualPrntDualObject
  : ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>
{
}

public interface ItestRefCnstPrntDualPrntDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualPrntDualObject<TRef>? As_RefCnstPrntDualPrntDual { get; }
}

public interface ItestRefCnstPrntDualPrntDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntDualPrntDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstPrntDualPrntDualObject? As_PrntCnstPrntDualPrntDual { get; }
}

public interface ItestPrntCnstPrntDualPrntDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
  ItestAltCnstPrntDualPrntDualObject? As_AltCnstPrntDualPrntDual { get; }
}

public interface ItestAltCnstPrntDualPrntDualObject
  : ItestPrntCnstPrntDualPrntDualObject
{
  decimal Alt { get; }
}
