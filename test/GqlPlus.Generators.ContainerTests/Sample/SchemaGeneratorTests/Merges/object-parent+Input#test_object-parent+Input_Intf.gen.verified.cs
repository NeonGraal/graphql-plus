//HintName: test_object-parent+Input_Intf.gen.cs
// Generated from object-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Input;

public interface ItestObjPrntInp
  : ItestRefObjPrntInp
{
  ItestObjPrntInpObject AsObjPrntInp { get; }
}

public interface ItestObjPrntInpObject
  : ItestRefObjPrntInpObject
{
}

public interface ItestRefObjPrntInp
{
  ItestRefObjPrntInpObject AsRefObjPrntInp { get; }
}

public interface ItestRefObjPrntInpObject
{
}
