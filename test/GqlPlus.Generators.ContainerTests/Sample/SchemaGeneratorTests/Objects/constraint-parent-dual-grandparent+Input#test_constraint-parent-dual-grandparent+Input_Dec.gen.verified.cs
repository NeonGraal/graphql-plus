//HintName: test_constraint-parent-dual-grandparent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  // No Base because it's Class
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualGrndInpObject<TRef>? As_RefCnstPrntDualGrndInp { get; }
}

public interface ItestRefCnstPrntDualGrndInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestGrndCnstPrntDualGrndInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestGrndCnstPrntDualGrndInpObject? As_GrndCnstPrntDualGrndInp { get; }
}

public interface ItestGrndCnstPrntDualGrndInpObject
  // No Base because it's Class
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
