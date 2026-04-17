//HintName: test_generic-parent-descr+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Output;

public class testGnrcPrntDescrOutp<TType>
  : GqlpModelBase
  , ItestGnrcPrntDescrOutp<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntDescrOutpObject<TType>? As_GnrcPrntDescrOutp { get; set; }
}

public class testGnrcPrntDescrOutpObject<TType>
  : GqlpModelBase
  , ItestGnrcPrntDescrOutpObject<TType>
{

  public testGnrcPrntDescrOutpObject
    ()
  {
  }
}
