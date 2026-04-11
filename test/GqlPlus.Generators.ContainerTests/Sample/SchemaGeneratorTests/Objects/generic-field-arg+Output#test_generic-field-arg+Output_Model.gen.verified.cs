//HintName: test_generic-field-arg+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Output;

public class testGnrcFieldArgOutp<TType>
  : GqlpModelBase
  , ItestGnrcFieldArgOutp<TType>
{
  public ItestGnrcFieldArgOutpObject<TType>? As_GnrcFieldArgOutp { get; set; }
}

public class testGnrcFieldArgOutpObject<TType>
  : GqlpModelBase
  , ItestGnrcFieldArgOutpObject<TType>
{
  public ItestRefGnrcFieldArgOutp<TType> Field { get; set; }

  public testGnrcFieldArgOutpObject
    ( ItestRefGnrcFieldArgOutp<TType> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldArgOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldArgOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldArgOutpObject<TRef>? As_RefGnrcFieldArgOutp { get; set; }
}

public class testRefGnrcFieldArgOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldArgOutpObject<TRef>
{

  public testRefGnrcFieldArgOutpObject
    ()
  {
  }
}
