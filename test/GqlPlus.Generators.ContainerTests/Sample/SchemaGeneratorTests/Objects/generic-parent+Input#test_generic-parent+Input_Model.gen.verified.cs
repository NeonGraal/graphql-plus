//HintName: test_generic-parent+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Input;

public class testGnrcPrntInp<TType>
  : GqlpModelBase
  , ItestGnrcPrntInp<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntInpObject<TType>? As_GnrcPrntInp { get; set; }
}

public class testGnrcPrntInpObject<TType>
  : GqlpModelBase
  , ItestGnrcPrntInpObject<TType>
{

  public testGnrcPrntInpObject
    ()
  {
  }
}
