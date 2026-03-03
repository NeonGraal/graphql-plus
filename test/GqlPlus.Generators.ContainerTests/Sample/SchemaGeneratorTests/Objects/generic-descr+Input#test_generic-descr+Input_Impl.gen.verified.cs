//HintName: test_generic-descr+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Input;

public class testGnrcDescrInp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcDescrInp<TType>
{
  public ItestGnrcDescrInpObject<TType>? As_GnrcDescrInp { get; set; }
}

public class testGnrcDescrInpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcDescrInpObject<TType>
{
  public TType Field { get; set; }

  public testGnrcDescrInpObject
    ( TType field
    )
  {
    Field = field;
  }
}
