//HintName: test_constraint-parent-dual-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public interface ItestCnstPrntDualPrntInp
  : ItestRefCnstPrntDualPrntInp<ItestAltCnstPrntDualPrntInp>
{
  ItestCnstPrntDualPrntInpObject? As_CnstPrntDualPrntInp { get; }
}

public interface ItestCnstPrntDualPrntInpObject
  : ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>
{
}

public interface ItestRefCnstPrntDualPrntInp<TRef>
  // No Base because it's Class
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualPrntInpObject<TRef>? As_RefCnstPrntDualPrntInp { get; }
}

public interface ItestRefCnstPrntDualPrntInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestPrntCnstPrntDualPrntInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstPrntDualPrntInpObject? As_PrntCnstPrntDualPrntInp { get; }
}

public interface ItestPrntCnstPrntDualPrntInpObject
  // No Base because it's Class
{
}

public interface ItestAltCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  ItestAltCnstPrntDualPrntInpObject? As_AltCnstPrntDualPrntInp { get; }
}

public interface ItestAltCnstPrntDualPrntInpObject
  : ItestPrntCnstPrntDualPrntInpObject
{
  decimal Alt { get; }
}
