//HintName: test_generic-field+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Output;

public class testGnrcFieldOutp<TType>
  : GqlpModelBase
  , ItestGnrcFieldOutp<TType>
{
  public ItestGnrcFieldOutpObject<TType>? As_GnrcFieldOutp { get; set; }
}

public class testGnrcFieldOutpObject<TType>
  : GqlpModelBase
  , ItestGnrcFieldOutpObject<TType>
{
  public TType Field { get; set; }

  public testGnrcFieldOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}
