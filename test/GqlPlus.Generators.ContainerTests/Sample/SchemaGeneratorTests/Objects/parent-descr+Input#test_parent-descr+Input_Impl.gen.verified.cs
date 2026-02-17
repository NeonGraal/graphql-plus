//HintName: test_parent-descr+Input_Impl.gen.cs
// Generated from {CurrentDirectory}parent-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

public class testPrntDescrInp
  : testRefPrntDescrInp
  , ItestPrntDescrInp
{
}

public class testRefPrntDescrInp
  : ItestRefPrntDescrInp
{
  public decimal Parent { get; set; }
}
