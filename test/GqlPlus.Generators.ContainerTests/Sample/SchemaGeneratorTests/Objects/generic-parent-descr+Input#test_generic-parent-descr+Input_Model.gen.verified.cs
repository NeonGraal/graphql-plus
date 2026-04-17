//HintName: test_generic-parent-descr+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Input;

public class testGnrcPrntDescrInp<TType>
  : GqlpModelBase
  , ItestGnrcPrntDescrInp<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntDescrInpObject<TType>? As_GnrcPrntDescrInp { get; set; }
}

public class testGnrcPrntDescrInpObject<TType>
  : GqlpModelBase
  , ItestGnrcPrntDescrInpObject<TType>
{

  public testGnrcPrntDescrInpObject
    ()
  {
  }
}
