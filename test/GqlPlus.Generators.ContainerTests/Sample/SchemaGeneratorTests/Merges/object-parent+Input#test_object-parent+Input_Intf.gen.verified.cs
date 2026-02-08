//HintName: test_object-parent+Input_Intf.gen.cs
// Generated from object-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Input;

public interface ItestObjPrntInp
  : ItestRefObjPrntInp
{
  public ItestObjPrntInpObject AsObjPrntInp { get; set; }
}

public interface ItestObjPrntInpObject
  : ItestRefObjPrntInpObject
{
}

public interface ItestRefObjPrntInp
{
  public ItestRefObjPrntInpObject AsRefObjPrntInp { get; set; }
}

public interface ItestRefObjPrntInpObject
{
}
