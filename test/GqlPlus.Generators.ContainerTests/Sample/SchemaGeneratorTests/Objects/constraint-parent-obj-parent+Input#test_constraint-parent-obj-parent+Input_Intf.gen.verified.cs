//HintName: test_constraint-parent-obj-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

public interface ItestCnstPrntObjPrntInp
  : ItestRefCnstPrntObjPrntInp<ItestAltCnstPrntObjPrntInp>
{
  ItestCnstPrntObjPrntInpObject? As_CnstPrntObjPrntInp { get; }
}

public interface ItestCnstPrntObjPrntInpObject
  : ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>
{
}

public interface ItestRefCnstPrntObjPrntInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntObjPrntInpObject<TRef>? As_RefCnstPrntObjPrntInp { get; }
}

public interface ItestRefCnstPrntObjPrntInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntObjPrntInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstPrntObjPrntInpObject? As_PrntCnstPrntObjPrntInp { get; }
}

public interface ItestPrntCnstPrntObjPrntInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
  ItestAltCnstPrntObjPrntInpObject? As_AltCnstPrntObjPrntInp { get; }
}

public interface ItestAltCnstPrntObjPrntInpObject
  : ItestPrntCnstPrntObjPrntInpObject
{
  decimal Alt { get; }
}
