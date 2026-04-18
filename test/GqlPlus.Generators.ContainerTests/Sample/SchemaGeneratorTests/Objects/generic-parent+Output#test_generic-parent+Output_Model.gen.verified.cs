//HintName: test_generic-parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Output;

public class testGnrcPrntOutp<TType>
  : GqlpModelBase
  , ItestGnrcPrntOutp<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntOutpObject<TType>? As_GnrcPrntOutp { get; set; }
}

public class testGnrcPrntOutpObject<TType>
  : GqlpModelBase
  , ItestGnrcPrntOutpObject<TType>
{

  public testGnrcPrntOutpObject
    ()
  {
  }
}
