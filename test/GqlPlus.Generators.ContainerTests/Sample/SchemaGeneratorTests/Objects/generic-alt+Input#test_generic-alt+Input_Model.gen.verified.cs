//HintName: test_generic-alt+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Input;

public class testGnrcAltInp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltInp<TType>
{
  public TType? Astype { get; set; }
  public ItestGnrcAltInpObject<TType>? As_GnrcAltInp { get; set; }
}

public class testGnrcAltInpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltInpObject<TType>
{

  public testGnrcAltInpObject
    ()
  {
  }
}
