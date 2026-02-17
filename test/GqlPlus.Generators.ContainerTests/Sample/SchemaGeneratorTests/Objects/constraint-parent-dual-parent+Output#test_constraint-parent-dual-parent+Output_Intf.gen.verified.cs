//HintName: test_constraint-parent-dual-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

public interface ItestCnstPrntDualPrntOutp
  : ItestRefCnstPrntDualPrntOutp<ItestAltCnstPrntDualPrntOutp>
{
  ItestCnstPrntDualPrntOutpObject? As_CnstPrntDualPrntOutp { get; }
}

public interface ItestCnstPrntDualPrntOutpObject
  : ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>
{
}

public interface ItestRefCnstPrntDualPrntOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualPrntOutpObject<TRef>? As_RefCnstPrntDualPrntOutp { get; }
}

public interface ItestRefCnstPrntDualPrntOutpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestPrntCnstPrntDualPrntOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstPrntDualPrntOutpObject? As_PrntCnstPrntDualPrntOutp { get; }
}

public interface ItestPrntCnstPrntDualPrntOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
  ItestAltCnstPrntDualPrntOutpObject? As_AltCnstPrntDualPrntOutp { get; }
}

public interface ItestAltCnstPrntDualPrntOutpObject
  : ItestPrntCnstPrntDualPrntOutpObject
{
  decimal Alt { get; }
}
