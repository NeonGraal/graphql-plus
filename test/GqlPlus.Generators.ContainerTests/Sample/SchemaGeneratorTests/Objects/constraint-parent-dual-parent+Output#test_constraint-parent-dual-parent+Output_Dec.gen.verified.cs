//HintName: test_constraint-parent-dual-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
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
  // No Base because it's Class
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualPrntOutpObject<TRef>? As_RefCnstPrntDualPrntOutp { get; }
}

public interface ItestRefCnstPrntDualPrntOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestPrntCnstPrntDualPrntOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstPrntDualPrntOutpObject? As_PrntCnstPrntDualPrntOutp { get; }
}

public interface ItestPrntCnstPrntDualPrntOutpObject
  // No Base because it's Class
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
