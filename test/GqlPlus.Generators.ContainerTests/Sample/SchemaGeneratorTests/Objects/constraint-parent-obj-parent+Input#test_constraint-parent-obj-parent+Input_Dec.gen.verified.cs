//HintName: test_constraint-parent-obj-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
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
  // No Base because it's Class
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntObjPrntInpObject<TRef>? As_RefCnstPrntObjPrntInp { get; }
}

public interface ItestRefCnstPrntObjPrntInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestPrntCnstPrntObjPrntInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstPrntObjPrntInpObject? As_PrntCnstPrntObjPrntInp { get; }
}

public interface ItestPrntCnstPrntObjPrntInpObject
  // No Base because it's Class
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
