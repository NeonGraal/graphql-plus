//HintName: test_constraint-parent-dual-grandparent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

public interface ItestCnstPrntDualGrndInp
  : ItestRefCnstPrntDualGrndInp<ItestAltCnstPrntDualGrndInp>
{
  ItestCnstPrntDualGrndInpObject? As_CnstPrntDualGrndInp { get; }
}

public interface ItestCnstPrntDualGrndInpObject
  : ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>
{
}

public interface ItestRefCnstPrntDualGrndInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualGrndInpObject<TRef>? As_RefCnstPrntDualGrndInp { get; }
}

public interface ItestRefCnstPrntDualGrndInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGrndCnstPrntDualGrndInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestGrndCnstPrntDualGrndInpObject? As_GrndCnstPrntDualGrndInp { get; }
}

public interface ItestGrndCnstPrntDualGrndInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
  ItestPrntCnstPrntDualGrndInpObject? As_PrntCnstPrntDualGrndInp { get; }
}

public interface ItestPrntCnstPrntDualGrndInpObject
  : ItestGrndCnstPrntDualGrndInpObject
{
}

public interface ItestAltCnstPrntDualGrndInp
  : ItestPrntCnstPrntDualGrndInp
{
  ItestAltCnstPrntDualGrndInpObject? As_AltCnstPrntDualGrndInp { get; }
}

public interface ItestAltCnstPrntDualGrndInpObject
  : ItestPrntCnstPrntDualGrndInpObject
{
  decimal Alt { get; }
}
