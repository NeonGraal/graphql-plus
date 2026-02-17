//HintName: test_constraint-parent-obj-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

public interface ItestCnstPrntObjPrntDual
  : ItestRefCnstPrntObjPrntDual<ItestAltCnstPrntObjPrntDual>
{
  ItestCnstPrntObjPrntDualObject AsCnstPrntObjPrntDual { get; }
}

public interface ItestCnstPrntObjPrntDualObject
  : ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>
{
}

public interface ItestRefCnstPrntObjPrntDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef AsParent { get; }
  ItestRefCnstPrntObjPrntDualObject<TRef> AsRefCnstPrntObjPrntDual { get; }
}

public interface ItestRefCnstPrntObjPrntDualObject<TRef>
{
}

public interface ItestPrntCnstPrntObjPrntDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstPrntObjPrntDualObject AsPrntCnstPrntObjPrntDual { get; }
}

public interface ItestPrntCnstPrntObjPrntDualObject
{
}

public interface ItestAltCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  ItestAltCnstPrntObjPrntDualObject AsAltCnstPrntObjPrntDual { get; }
}

public interface ItestAltCnstPrntObjPrntDualObject
  : ItestPrntCnstPrntObjPrntDualObject
{
  decimal Alt { get; }
}
