//HintName: test_constraint-parent-obj-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntObjPrntDualObject<TRef>? As_RefCnstPrntObjPrntDual { get; }
}

public interface ItestRefCnstPrntObjPrntDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntObjPrntDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstPrntObjPrntDualObject? As_PrntCnstPrntObjPrntDual { get; }
}

public interface ItestPrntCnstPrntObjPrntDualObject
  : IGqlpInterfaceBase
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
