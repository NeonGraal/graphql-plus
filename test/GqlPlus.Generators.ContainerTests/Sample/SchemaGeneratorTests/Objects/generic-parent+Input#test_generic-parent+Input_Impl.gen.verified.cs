//HintName: test_generic-parent+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Input;

public class testGnrcPrntInp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcPrntInp<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntInpObject<TType>? As_GnrcPrntInp { get; set; }
}

public class testGnrcPrntInpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcPrntInpObject<TType>
{

  public testGnrcPrntInpObject
    ()
  {
  }
}
