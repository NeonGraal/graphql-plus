//HintName: test_generic-value+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public class testGnrcValueOutp
  : GqlpModelBase
  , ItestGnrcValueOutp
{
  public ItestRefGnrcValueOutp<testEnumGnrcValueOutp>? AsEnumGnrcValueOutpgnrcValueOutp { get; set; }
  public ItestGnrcValueOutpObject? As_GnrcValueOutp { get; set; }
}

public class testGnrcValueOutpObject
  : GqlpModelBase
  , ItestGnrcValueOutpObject
{

  public testGnrcValueOutpObject
    ()
  {
  }
}

public class testRefGnrcValueOutp<TType>
  : GqlpModelBase
  , ItestRefGnrcValueOutp<TType>
{
  public ItestRefGnrcValueOutpObject<TType>? As_RefGnrcValueOutp { get; set; }
}

public class testRefGnrcValueOutpObject<TType>
  : GqlpModelBase
  , ItestRefGnrcValueOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcValueOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}
