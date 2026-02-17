//HintName: test_constraint-parent-dual-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public interface ItestCnstPrntDualPrntInp
  : ItestRefCnstPrntDualPrntInp<ItestAltCnstPrntDualPrntInp>
{
  ItestCnstPrntDualPrntInpObject AsCnstPrntDualPrntInp { get; }
}

public interface ItestCnstPrntDualPrntInpObject
  : ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>
{
}

public interface ItestRefCnstPrntDualPrntInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef AsParent { get; }
  ItestRefCnstPrntDualPrntInpObject<TRef> AsRefCnstPrntDualPrntInp { get; }
}

public interface ItestRefCnstPrntDualPrntInpObject<TRef>
{
}

public interface ItestPrntCnstPrntDualPrntInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstPrntDualPrntInpObject AsPrntCnstPrntDualPrntInp { get; }
}

public interface ItestPrntCnstPrntDualPrntInpObject
{
}

public interface ItestAltCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  ItestAltCnstPrntDualPrntInpObject AsAltCnstPrntDualPrntInp { get; }
}

public interface ItestAltCnstPrntDualPrntInpObject
  : ItestPrntCnstPrntDualPrntInpObject
{
  decimal Alt { get; }
}
