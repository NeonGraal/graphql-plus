//HintName: test_generic-parent+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Output;

public class testGnrcPrntOutp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcPrntOutp<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntOutpObject<TType>? As_GnrcPrntOutp { get; set; }
}

public class testGnrcPrntOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcPrntOutpObject<TType>
{

  public testGnrcPrntOutpObject()
  {
  }
}
