//HintName: test_constraint-parent-dual-grandparent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

public interface ItestCnstPrntDualGrndDual
  : ItestRefCnstPrntDualGrndDual<ItestAltCnstPrntDualGrndDual>
{
  ItestCnstPrntDualGrndDualObject? As_CnstPrntDualGrndDual { get; }
}

public interface ItestCnstPrntDualGrndDualObject
  : ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>
{
}

public interface ItestRefCnstPrntDualGrndDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualGrndDualObject<TRef>? As_RefCnstPrntDualGrndDual { get; }
}

public interface ItestRefCnstPrntDualGrndDualObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestGrndCnstPrntDualGrndDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestGrndCnstPrntDualGrndDualObject? As_GrndCnstPrntDualGrndDual { get; }
}

public interface ItestGrndCnstPrntDualGrndDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestPrntCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
  ItestPrntCnstPrntDualGrndDualObject? As_PrntCnstPrntDualGrndDual { get; }
}

public interface ItestPrntCnstPrntDualGrndDualObject
  : ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestAltCnstPrntDualGrndDual
  : ItestPrntCnstPrntDualGrndDual
{
  ItestAltCnstPrntDualGrndDualObject? As_AltCnstPrntDualGrndDual { get; }
}

public interface ItestAltCnstPrntDualGrndDualObject
  : ItestPrntCnstPrntDualGrndDualObject
{
  decimal Alt { get; }
}
