//HintName: test_generic-field+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Input;

public class testGnrcFieldInp<TType>
  : GqlpModelBase
  , ItestGnrcFieldInp<TType>
{
  public ItestGnrcFieldInpObject<TType>? As_GnrcFieldInp { get; set; }
}

public class testGnrcFieldInpObject<TType>
  : GqlpModelBase
  , ItestGnrcFieldInpObject<TType>
{
  public TType Field { get; set; }

  public testGnrcFieldInpObject
    ( TType pfield
    )
  {
    Field = pfield;
  }
}
