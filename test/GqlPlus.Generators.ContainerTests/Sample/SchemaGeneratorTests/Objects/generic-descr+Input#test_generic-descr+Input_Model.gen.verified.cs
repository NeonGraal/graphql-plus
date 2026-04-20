//HintName: test_generic-descr+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Input;

public class testGnrcDescrInp<TType>
  : GqlpModelBase
  , ItestGnrcDescrInp<TType>
{
  public ItestGnrcDescrInpObject<TType>? As_GnrcDescrInp { get; set; }
}

public class testGnrcDescrInpObject<TType>
  : GqlpModelBase
  , ItestGnrcDescrInpObject<TType>
{
  public TType Field { get; set; }

  public testGnrcDescrInpObject
    ( TType pfield
    )
  {
    Field = pfield;
  }
}
