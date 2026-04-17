//HintName: test_constraint-parent-dual-grandparent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

public interface ItestCnstPrntDualGrndOutp
  : ItestRefCnstPrntDualGrndOutp<ItestAltCnstPrntDualGrndOutp>
{
  ItestCnstPrntDualGrndOutpObject? As_CnstPrntDualGrndOutp { get; }
}

public interface ItestCnstPrntDualGrndOutpObject
  : ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>
{
}

public interface ItestRefCnstPrntDualGrndOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualGrndOutpObject<TRef>? As_RefCnstPrntDualGrndOutp { get; }
}

public interface ItestRefCnstPrntDualGrndOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGrndCnstPrntDualGrndOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestGrndCnstPrntDualGrndOutpObject? As_GrndCnstPrntDualGrndOutp { get; }
}

public interface ItestGrndCnstPrntDualGrndOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
  ItestPrntCnstPrntDualGrndOutpObject? As_PrntCnstPrntDualGrndOutp { get; }
}

public interface ItestPrntCnstPrntDualGrndOutpObject
  : ItestGrndCnstPrntDualGrndOutpObject
{
}

public interface ItestAltCnstPrntDualGrndOutp
  : ItestPrntCnstPrntDualGrndOutp
{
  ItestAltCnstPrntDualGrndOutpObject? As_AltCnstPrntDualGrndOutp { get; }
}

public interface ItestAltCnstPrntDualGrndOutpObject
  : ItestPrntCnstPrntDualGrndOutpObject
{
  decimal Alt { get; }
}
