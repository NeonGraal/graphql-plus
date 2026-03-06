//HintName: test_constraint-parent-dual-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  : IGqlpModelImplementationBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualPrntDualObject<TRef>? As_RefCnstPrntDualPrntDual { get; }
}

public interface ItestRefCnstPrntDualPrntDualObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestPrntCnstPrntDualPrntDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstPrntDualPrntDualObject? As_PrntCnstPrntDualPrntDual { get; }
}

public interface ItestPrntCnstPrntDualPrntDualObject
  : IGqlpModelImplementationBase
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
