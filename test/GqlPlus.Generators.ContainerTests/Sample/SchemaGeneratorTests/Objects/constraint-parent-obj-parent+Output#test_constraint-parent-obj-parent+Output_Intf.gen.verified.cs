//HintName: test_constraint-parent-obj-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

public interface ItestCnstPrntObjPrntOutp
  : ItestRefCnstPrntObjPrntOutp<ItestAltCnstPrntObjPrntOutp>
{
  ItestCnstPrntObjPrntOutpObject? As_CnstPrntObjPrntOutp { get; }
}

public interface ItestCnstPrntObjPrntOutpObject
  : ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>
{
}

public interface ItestRefCnstPrntObjPrntOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntObjPrntOutpObject<TRef>? As_RefCnstPrntObjPrntOutp { get; }
}

public interface ItestRefCnstPrntObjPrntOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntObjPrntOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstPrntObjPrntOutpObject? As_PrntCnstPrntObjPrntOutp { get; }
}

public interface ItestPrntCnstPrntObjPrntOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
  ItestAltCnstPrntObjPrntOutpObject? As_AltCnstPrntObjPrntOutp { get; }
}

public interface ItestAltCnstPrntObjPrntOutpObject
  : ItestPrntCnstPrntObjPrntOutpObject
{
  decimal Alt { get; }
}
