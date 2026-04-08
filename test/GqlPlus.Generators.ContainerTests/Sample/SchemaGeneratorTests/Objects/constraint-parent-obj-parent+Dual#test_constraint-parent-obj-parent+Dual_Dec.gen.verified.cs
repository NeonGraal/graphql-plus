//HintName: test_constraint-parent-obj-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public interface ItestCnstPrntObjPrntDual
  : ItestRefCnstPrntObjPrntDual<ItestAltCnstPrntObjPrntDual>
{
  ItestCnstPrntObjPrntDualObject? As_CnstPrntObjPrntDual { get; }
}

public interface ItestCnstPrntObjPrntDualObject
  : ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>
{
}

public interface ItestRefCnstPrntObjPrntDual<TRef>
  // No Base because it's Class
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntObjPrntDualObject<TRef>? As_RefCnstPrntObjPrntDual { get; }
}

public interface ItestRefCnstPrntObjPrntDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestPrntCnstPrntObjPrntDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstPrntObjPrntDualObject? As_PrntCnstPrntObjPrntDual { get; }
}

public interface ItestPrntCnstPrntObjPrntDualObject
  // No Base because it's Class
{
}

public interface ItestAltCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  ItestAltCnstPrntObjPrntDualObject? As_AltCnstPrntObjPrntDual { get; }
}

public interface ItestAltCnstPrntObjPrntDualObject
  : ItestPrntCnstPrntObjPrntDualObject
{
  decimal Alt { get; }
}
