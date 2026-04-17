//HintName: test_generic-alt+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Input;

public class testGnrcAltInp<TType>
  : GqlpModelBase
  , ItestGnrcAltInp<TType>
{
  public TType? Astype { get; set; }
  public ItestGnrcAltInpObject<TType>? As_GnrcAltInp { get; set; }
}

public class testGnrcAltInpObject<TType>
  : GqlpModelBase
  , ItestGnrcAltInpObject<TType>
{

  public testGnrcAltInpObject
    ()
  {
  }
}
