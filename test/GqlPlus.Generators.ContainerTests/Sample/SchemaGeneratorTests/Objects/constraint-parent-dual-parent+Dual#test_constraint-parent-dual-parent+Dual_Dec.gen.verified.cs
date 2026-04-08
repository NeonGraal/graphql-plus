//HintName: test_constraint-parent-dual-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
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
  // No Base because it's Class
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualPrntDualObject<TRef>? As_RefCnstPrntDualPrntDual { get; }
}

public interface ItestRefCnstPrntDualPrntDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestPrntCnstPrntDualPrntDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstPrntDualPrntDualObject? As_PrntCnstPrntDualPrntDual { get; }
}

public interface ItestPrntCnstPrntDualPrntDualObject
  // No Base because it's Class
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
