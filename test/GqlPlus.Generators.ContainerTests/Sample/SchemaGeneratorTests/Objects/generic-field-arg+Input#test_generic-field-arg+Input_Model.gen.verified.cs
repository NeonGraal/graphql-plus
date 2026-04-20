//HintName: test_generic-field-arg+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public class testGnrcFieldArgInp<TType>
  : GqlpModelBase
  , ItestGnrcFieldArgInp<TType>
{
  public ItestGnrcFieldArgInpObject<TType>? As_GnrcFieldArgInp { get; set; }
}

public class testGnrcFieldArgInpObject<TType>
  : GqlpModelBase
  , ItestGnrcFieldArgInpObject<TType>
{
  public ItestRefGnrcFieldArgInp<TType> Field { get; set; }

  public testGnrcFieldArgInpObject
    ( ItestRefGnrcFieldArgInp<TType> pfield
    )
  {
    Field = pfield;
  }
}

public class testRefGnrcFieldArgInp<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldArgInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldArgInpObject<TRef>? As_RefGnrcFieldArgInp { get; set; }
}

public class testRefGnrcFieldArgInpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldArgInpObject<TRef>
{

  public testRefGnrcFieldArgInpObject
    ()
  {
  }
}
