//HintName: test_object-parent+Output_Intf.gen.cs
// Generated from object-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Output;

public interface ItestObjPrntOutp
  : ItestRefObjPrntOutp
{
  public ItestObjPrntOutpObject AsObjPrntOutp { get; set; }
}

public interface ItestObjPrntOutpObject
  : ItestRefObjPrntOutpObject
{
}

public interface ItestRefObjPrntOutp
{
  public ItestRefObjPrntOutpObject AsRefObjPrntOutp { get; set; }
}

public interface ItestRefObjPrntOutpObject
{
}
