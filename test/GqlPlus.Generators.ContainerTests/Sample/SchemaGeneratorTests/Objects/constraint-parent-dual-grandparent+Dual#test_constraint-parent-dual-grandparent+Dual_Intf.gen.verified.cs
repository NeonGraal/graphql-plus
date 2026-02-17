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
  ItestCnstPrntDualGrndDualObject AsCnstPrntDualGrndDual { get; }
}

public interface ItestCnstPrntDualGrndDualObject
  : ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>
{
}

public interface ItestRefCnstPrntDualGrndDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef AsParent { get; }
  ItestRefCnstPrntDualGrndDualObject<TRef> AsRefCnstPrntDualGrndDual { get; }
}

public interface ItestRefCnstPrntDualGrndDualObject<TRef>
{
}

public interface ItestGrndCnstPrntDualGrndDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestGrndCnstPrntDualGrndDualObject AsGrndCnstPrntDualGrndDual { get; }
}

public interface ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestPrntCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
  ItestPrntCnstPrntDualGrndDualObject AsPrntCnstPrntDualGrndDual { get; }
}

public interface ItestPrntCnstPrntDualGrndDualObject
  : ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestAltCnstPrntDualGrndDual
  : ItestPrntCnstPrntDualGrndDual
{
  ItestAltCnstPrntDualGrndDualObject AsAltCnstPrntDualGrndDual { get; }
}

public interface ItestAltCnstPrntDualGrndDualObject
  : ItestPrntCnstPrntDualGrndDualObject
{
  decimal Alt { get; }
}
