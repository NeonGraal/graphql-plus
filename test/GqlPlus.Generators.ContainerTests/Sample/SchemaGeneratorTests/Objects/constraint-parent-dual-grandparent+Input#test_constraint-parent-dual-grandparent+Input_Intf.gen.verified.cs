//HintName: test_constraint-parent-dual-grandparent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public interface ItestCnstPrntDualGrndInp
  : ItestRefCnstPrntDualGrndInp<ItestAltCnstPrntDualGrndInp>
{
  ItestCnstPrntDualGrndInpObject AsCnstPrntDualGrndInp { get; }
}

public interface ItestCnstPrntDualGrndInpObject
  : ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>
{
}

public interface ItestRefCnstPrntDualGrndInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef AsParent { get; }
  ItestRefCnstPrntDualGrndInpObject<TRef> AsRefCnstPrntDualGrndInp { get; }
}

public interface ItestRefCnstPrntDualGrndInpObject<TRef>
{
}

public interface ItestGrndCnstPrntDualGrndInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestGrndCnstPrntDualGrndInpObject AsGrndCnstPrntDualGrndInp { get; }
}

public interface ItestGrndCnstPrntDualGrndInpObject
{
}

public interface ItestPrntCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
  ItestPrntCnstPrntDualGrndInpObject AsPrntCnstPrntDualGrndInp { get; }
}

public interface ItestPrntCnstPrntDualGrndInpObject
  : ItestGrndCnstPrntDualGrndInpObject
{
}

public interface ItestAltCnstPrntDualGrndInp
  : ItestPrntCnstPrntDualGrndInp
{
  ItestAltCnstPrntDualGrndInpObject AsAltCnstPrntDualGrndInp { get; }
}

public interface ItestAltCnstPrntDualGrndInpObject
  : ItestPrntCnstPrntDualGrndInpObject
{
  decimal Alt { get; }
}
