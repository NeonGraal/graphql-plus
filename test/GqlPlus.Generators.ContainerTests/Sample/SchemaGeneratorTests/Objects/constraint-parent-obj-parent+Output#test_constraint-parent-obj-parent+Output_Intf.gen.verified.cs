//HintName: test_constraint-parent-obj-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Output;

public interface ItestCnstPrntObjPrntOutp
  : ItestRefCnstPrntObjPrntOutp<ItestAltCnstPrntObjPrntOutp>
{
  ItestCnstPrntObjPrntOutpObject AsCnstPrntObjPrntOutp { get; }
}

public interface ItestCnstPrntObjPrntOutpObject
  : ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>
{
}

public interface ItestRefCnstPrntObjPrntOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef AsParent { get; }
  ItestRefCnstPrntObjPrntOutpObject<TRef> AsRefCnstPrntObjPrntOutp { get; }
}

public interface ItestRefCnstPrntObjPrntOutpObject<TRef>
{
}

public interface ItestPrntCnstPrntObjPrntOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstPrntObjPrntOutpObject AsPrntCnstPrntObjPrntOutp { get; }
}

public interface ItestPrntCnstPrntObjPrntOutpObject
{
}

public interface ItestAltCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
  ItestAltCnstPrntObjPrntOutpObject AsAltCnstPrntObjPrntOutp { get; }
}

public interface ItestAltCnstPrntObjPrntOutpObject
  : ItestPrntCnstPrntObjPrntOutpObject
{
  decimal Alt { get; }
}
