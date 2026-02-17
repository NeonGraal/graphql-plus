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
  ItestCnstPrntDualPrntDualObject AsCnstPrntDualPrntDual { get; }
}

public interface ItestCnstPrntDualPrntDualObject
  : ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>
{
}

public interface ItestRefCnstPrntDualPrntDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef AsParent { get; }
  ItestRefCnstPrntDualPrntDualObject<TRef> AsRefCnstPrntDualPrntDual { get; }
}

public interface ItestRefCnstPrntDualPrntDualObject<TRef>
{
}

public interface ItestPrntCnstPrntDualPrntDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstPrntDualPrntDualObject AsPrntCnstPrntDualPrntDual { get; }
}

public interface ItestPrntCnstPrntDualPrntDualObject
{
}

public interface ItestAltCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
  ItestAltCnstPrntDualPrntDualObject AsAltCnstPrntDualPrntDual { get; }
}

public interface ItestAltCnstPrntDualPrntDualObject
  : ItestPrntCnstPrntDualPrntDualObject
{
  decimal Alt { get; }
}
